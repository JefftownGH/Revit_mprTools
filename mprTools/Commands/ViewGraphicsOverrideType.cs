namespace mprTools.Commands
{
    /// <summary>
    /// Тип переопределения графики в шаблоне
    /// </summary>
    public enum ViewGraphicsOverrideType
    {
        /// <summary>
        /// Категории модели
        /// </summary>
        Model,

        /// <summary>
        /// Категории аннотаций
        /// </summary>
        Annotation,

        /// <summary>
        /// Категории аналитической модели
        /// </summary>
        AnalyticalModel,

        /// <summary>
        /// Импортированные категории
        /// </summary>
        Import,

        /// <summary>
        /// Фильтры
        /// </summary>
        Filters
    }
}
