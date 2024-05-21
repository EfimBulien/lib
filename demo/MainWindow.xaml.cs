using System.Collections.ObjectModel;
using SerializationLibrary;
using System.IO;
using System.Windows;

namespace demo;

public partial class MainWindow
{
    private const string Theme = "LightBlueTheme";
    private const string Xml = "data.xml";
    private const string Json = "data.json";

    private ObservableCollection<Smartphone> Smartphones { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        Smartphones = new ObservableCollection<Smartphone>();
        SmartphoneDataGrid.ItemsSource = Smartphones;
    }

    private void SerializeToXml_Click(object sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Xml);
        SerializationHelper.SerializeXml(Smartphones.ToList(), filePath);
        MessageBox.Show($"Данные успешно сериализованы в XML. Файл сохранен по пути: {filePath}");
    }

    private void DeserializeFromXml_Click(object sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Xml);
        var data = SerializationHelper.DeserializeXml<List<Smartphone>>(filePath);
        Smartphones.Clear();
        foreach (var smartphone in data)
        {
            Smartphones.Add(smartphone);
        }
        MessageBox.Show($"Данные успешно десериализованы из XML. Файл загружен из: {filePath}");
    }

    private void SerializeToJson_Click(object sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Json);
        SerializationHelper.SerializeJson(Smartphones.ToList(), filePath);
        MessageBox.Show($"Данные успешно сериализованы в JSON. Файл сохранен по пути: {filePath}");
    }

    private void DeserializeFromJson_Click(object sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Json);
        var data = SerializationHelper.DeserializeJson<List<Smartphone>>(filePath);
        Smartphones.Clear();
        foreach (var smartphone in data!)
        {
            Smartphones.Add(smartphone);
        }
        MessageBox.Show($"Данные успешно десериализованы из JSON. Файл загружен из: {filePath}");
    }

    private void SwitchTheme_Click(object sender, RoutedEventArgs e)
    {
        var newTheme = new ResourceDictionary
        {
            Source = Application.Current.Resources.MergedDictionaries[0].Source.ToString().Contains(Theme) ? 
                new Uri("/ThemesLibrary;component/Themes/CoralTheme.xaml", UriKind.RelativeOrAbsolute) : 
                new Uri("/ThemesLibrary;component/Themes/LightBlueTheme.xaml", UriKind.RelativeOrAbsolute)
        };

        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(newTheme);
    }
}
