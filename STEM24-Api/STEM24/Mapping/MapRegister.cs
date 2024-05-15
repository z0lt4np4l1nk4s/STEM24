namespace STEM24.Mapping;

public class MapRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddEventDto, EventEntity>()
            .Map(destination => destination.MatchingKeywords, source => string.Join(";", source.MatchingKeywords));

        config.NewConfig<EventEntity, EventDto>()
            .Map(destination => destination.MatchingKeywords, source => string.IsNullOrEmpty(source.MatchingKeywords) ? new List<string>() : source.MatchingKeywords.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList());
    }
}
