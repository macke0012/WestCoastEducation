namespace WestCoastEducation.Interfaces;

public interface IService<T>
{
    void Create(T obj);
    void Update(T obj);
    void Delete(string id);
    List<T> GetAll();
    T GetSingle(string id);
}
