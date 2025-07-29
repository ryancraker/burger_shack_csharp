namespace burger_shack_csharp.Repositories;

public interface IRepository<T>
{
    List<T> GetAll();
    T GetById(int id);
    T Create(T data);
    T Delete(int id);
    T Update(int id, T updateData);
}
