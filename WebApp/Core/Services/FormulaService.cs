using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoEvaluacion.Core.Interfaces;
using ProyectoEvaluacion.Core.Models;
using ProyectoEvaluacion.Models;

namespace ProyectoEvaluacion.Core.Services
{
    /// <summary>
    /// Servicio para gestionar fórmulas con transacciones maestro-detalle
    /// </summary>
    public class FormulaService : IFormulaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Formula> _formulaRepository;
        private readonly IRepository<FormulaMateriale> _materialesRepository;

        public FormulaService(
            ApplicationDbContext context,
            IRepository<Formula> formulaRepository,
            IRepository<FormulaMateriale> materialesRepository)
        {
            _context = context;
            _formulaRepository = formulaRepository;
            _materialesRepository = materialesRepository;
        }

        public async Task<IEnumerable<Formula>> GetAllFormulasAsync()
        {
            return await _context.Formulas
                .Include(f => f.IdProductoNavigation)
                .Include(f => f.IdUsuarioCreacionNavigation)
                .OrderByDescending(f => f.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Formula?> GetFormulaByIdAsync(int id)
        {
            return await _context.Formulas
                .Include(f => f.IdProductoNavigation)
                .Include(f => f.IdUsuarioCreacionNavigation)
                .Include(f => f.IdUsuarioActualizacionNavigation)
                .FirstOrDefaultAsync(f => f.IdFormula == id);
        }

        /// <summary>
        /// Crea una fórmula con sus materiales en una sola transacción
        /// </summary>
        public async Task<Formula> CreateFormulaWithMaterialsAsync(
            Formula formula,
            List<FormulaMateriale> materiales,
            int usuarioId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Establecer datos de auditoría
                formula.IdUsuarioCreacion = usuarioId;
                formula.FechaCreacion = DateTime.Now;

                // Guardar fórmula (maestro)
                await _formulaRepository.AddAsync(formula);

                // Guardar materiales (detalle)
                if (materiales != null && materiales.Any())
                {
                    int linea = 1;
                    foreach (var material in materiales)
                    {
                        material.IdFormula = formula.IdFormula;
                        material.Linea = linea++;
                        await _materialesRepository.AddAsync(material);
                    }
                }

                await transaction.CommitAsync();
                return formula;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Actualiza una fórmula y sus materiales en una sola transacción
        /// </summary>
        public async Task UpdateFormulaWithMaterialsAsync(
            Formula formula,
            List<FormulaMateriales> materiales,
            int usuarioId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Establecer datos de auditoría
                formula.IdUsuarioActualizacion = usuarioId;
                formula.FechaActualizacion = DateTime.Now;

                // Actualizar fórmula (maestro)
                await _formulaRepository.UpdateAsync(formula);

                // Eliminar materiales existentes
                var materialesExistentes = await _context.FormulaMateriales
                    .Where(m => m.IdFormula == formula.IdFormula)
                    .ToListAsync();

                _context.FormulaMateriales.RemoveRange(materialesExistentes);

                // Agregar nuevos materiales (detalle)
                if (materiales != null && materiales.Any())
                {
                    int linea = 1;
                    foreach (var material in materiales)
                    {
                        material.IdFormula = formula.IdFormula;
                        material.Linea = linea++;
                        await _materialesRepository.AddAsync(material);
                    }
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteFormulaAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Eliminar materiales primero (detalle)
                var materiales = await _context.FormulaMateriales
                    .Where(m => m.IdFormula == id)
                    .ToListAsync();

                _context.FormulaMateriales.RemoveRange(materiales);

                // Eliminar fórmula (maestro)
                await _formulaRepository.DeleteAsync(id);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<FormulaMateriale>> GetMaterialesByFormulaAsync(int formulaId)
        {
            return await _context.FormulaMateriales
                .Include(m => m.IdProductoNavigation)
                .Where(m => m.IdFormula == formulaId)
                .OrderBy(m => m.Linea)
                .ToListAsync();
        }
    }
}