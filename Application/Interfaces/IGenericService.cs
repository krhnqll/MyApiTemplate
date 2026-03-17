namespace Application.Interfaces;

public interface IGenericService<TDto, CDto, UDto>
    where TDto : class
    where CDto : class
    where UDto : class
{
    Task<List<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);

    Task<TDto> CreateAsync(CDto dto);
    Task<TDto> UpdateAsync(UDto dto);

    Task<bool> DeleteAsync(int id);
}
