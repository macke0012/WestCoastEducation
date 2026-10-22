namespace WestCoastEducation.Interfaces;

public interface IStorageProvider
{
    void Save<T>(T obj) where T : IStorageObject;
    T? Get<T>(string id);
    void Delete(string id);
    List<T> GetAll<T>();
}
