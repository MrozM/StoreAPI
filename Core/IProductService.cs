namespace Core;

public interface IProductService
{
    Product GetById(int id);
    IEnumerable<Product> GetAll(); 
    void Add(Product product);

    bool Update(int id, string name);
    bool Delete(int id);
}