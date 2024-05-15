namespace STEM24.Mapping;

public class MapRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddEventDto, EventEntity>()
            .Map(destination => destination.Keywords, source => string.Join(";", source.Keywords));

        config.NewConfig<EventEntity, EventDto>()
            .Map(destination => destination.Keywords, source => string.IsNullOrEmpty(source.Keywords) ? new List<string>() : source.Keywords.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList());

        config.NewConfig<EventEntity, UpdateEventDto>()
            .Map(destination => destination.Keywords, source => string.Join(";", source.Keywords));
    }
}
