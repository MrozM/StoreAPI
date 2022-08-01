namespace Core;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    bool Update(int id, string name);
    bool Delete(int id);
}