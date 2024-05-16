using SerializationLibrary;
using System.IO;
using System.Windows;

namespace demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeToXml_Click(object sender, RoutedEventArgs e)
        {
            string data = DataTextBox.Text;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.xml");
            SerializationHelper.SerializeXml(data, filePath);
            MessageBox.Show($"Данные успешно сериализованы в XML. Файл сохранен по пути: {filePath}");
        }

        private void DeserializeFromXml_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.xml");
            string data = SerializationHelper.DeserializeXml<string>(filePath);
            DataTextBox.Text = data;
            MessageBox.Show($"Данные успешно десериализованы из XML. Файл загружен из: {filePath}");
        }

        private void SerializeToJson_Click(object sender, RoutedEventArgs e)
        {
            string data = DataTextBox.Text;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.json");
            SerializationHelper.SerializeJson(data, filePath);
            MessageBox.Show($"Данные успешно сериализованы в JSON. Файл сохранен по пути: {filePath}");
        }

        private void DeserializeFromJson_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.json");
            string data = SerializationHelper.DeserializeJson<string>(filePath);
            DataTextBox.Text = data;
            MessageBox.Show($"Данные успешно десериализованы из JSON. Файл загружен из: {filePath}");
        }

        private void SwitchTheme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newTheme = new ResourceDictionary();

            if (Application.Current.Resources.MergedDictionaries[0].Source.ToString().Contains("LightBlueTheme"))
            {
                newTheme.Source = new System.Uri("/ThemesLibrary;component/Themes/CoralTheme.xaml", System.UriKind.RelativeOrAbsolute);
            }
            else
            {
                newTheme.Source = new System.Uri("/ThemesLibrary;component/Themes/LightBlueTheme.xaml", System.UriKind.RelativeOrAbsolute);
            }

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}