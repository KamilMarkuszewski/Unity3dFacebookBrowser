namespace Assets.Scripts.FacebookService.Entities
{
    public abstract class JsonSerializableBase
    {
        public abstract void FillFromJson<T>(string jsonString);
    }
}
