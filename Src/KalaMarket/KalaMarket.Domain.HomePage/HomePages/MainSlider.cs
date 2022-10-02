using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.HomePage.HomePages;

public class MainSlider : BaseEntity<long>
{
    public string Src { get; private set; }

    public MainSlider(string src)
    {
        Src = src;
    }
    public void Edit(string src)
    {
        Src = src;
    }
}