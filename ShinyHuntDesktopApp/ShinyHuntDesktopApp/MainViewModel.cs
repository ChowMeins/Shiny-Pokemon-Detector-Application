using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using System.IO.Ports;
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
    public List<string> PokemonNames { get; private set; }
    public List<string> MethodTypes { get; private set; }
    public List<string> ComPorts { get; private set; }
    public MainViewModel()
    {
        PokemonNames = _dataService.LoadPokemonNames();
        MethodTypes = _dataService.LoadMethodTypes();
        ComPorts = _dataService.LoadComPorts();
    }
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
