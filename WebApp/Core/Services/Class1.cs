using Core;
using ProyectoEvaluacion.Models;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _db;
    public ProductoRepository(ApplicationDbContext db) => _db = db;

    public async Task<IEnumerable<Producto>> GetAllAsync() => await _db.Productos.ToListAsync();
    public async Task<Producto?> GetByIdAsync(int id) => await _db.Productos.FindAsync(id);
    public async Task AddAsync(Producto producto) { await _db.Productos.AddAsync(producto); }
    public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
}