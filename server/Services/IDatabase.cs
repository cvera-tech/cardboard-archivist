namespace CardboardArchivistApi.Services;

public interface IDatabase
{
    public void Commit();
    public void Create(string tableName, object item);
    public void Delete(string tableName, string id);
    public void Get(string tableName, string id);
    public void Update(string tableName, object item);
}