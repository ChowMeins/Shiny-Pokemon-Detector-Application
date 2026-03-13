using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly AppDataService _dataService = new AppDataService();
    private BitmapSource? currentFrame;
    public BitmapSource? CurrentFrame
    {
        get { return currentFrame; }
        set
        {
            currentFrame = value;
            OnPropertyChanged();
        }
    }
    public List<string> PokemonNames { get; set; }

    public MainViewModel()
    {
        PokemonNames = _dataService.LoadPokemonNames();
    }
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
