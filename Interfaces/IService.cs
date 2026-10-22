using WestCoastEducation.Services;

namespace WestCoastEducation.Interfaces;

public interface IService<T>
{

    void Delete(string id);
    void Create(T obj);
    List<T> GetAll();
    T GetSingle(string id);








}