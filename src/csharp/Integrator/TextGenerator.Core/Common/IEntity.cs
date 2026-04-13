namespace TextGenerator.Core.Common
{
    /// <summary>
    /// Базовый интерфейс для всех сущностей, имеющих уникальный идентификатор.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Уникальный идентификатор сущности.</summary>
        public Guid Id { get; }
    }
}
