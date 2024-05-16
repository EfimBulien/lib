using SerializationLibrary;
using System.IO;
using System.Windows;

namespace demo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeToXml_Click(object sender, RoutedEventArgs e)
        {
            var data = DataTextBox.Text;
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.xml");
            SerializationHelper.SerializeXml(data, filePath);
            MessageBox.Show($"Данные успешно сериализованы в XML. Файл сохранен по пути: {filePath}");
        }

        private void DeserializeFromXml_Click(object sender, RoutedEventArgs e)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.xml");
            var data = SerializationHelper.DeserializeXml<string>(filePath);
            DataTextBox.Text = data;
            MessageBox.Show($"Данные успешно десериализованы из XML. Файл загружен из: {filePath}");
        }

        private void SerializeToJson_Click(object sender, RoutedEventArgs e)
        {
            var data = DataTextBox.Text;
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.json");
            SerializationHelper.SerializeJson(data, filePath);
            MessageBox.Show($"Данные успешно сериализованы в JSON. Файл сохранен по пути: {filePath}");
        }

        private void DeserializeFromJson_Click(object sender, RoutedEventArgs e)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.json");
            var data = SerializationHelper.DeserializeJson<string>(filePath);
            if (data != null) DataTextBox.Text = data;
            MessageBox.Show($"Данные успешно десериализованы из JSON. Файл загружен из: {filePath}");
        }

        private void SwitchTheme_Click(object sender, RoutedEventArgs e)
        {
            var newTheme = new ResourceDictionary
            {
                Source = Application.Current.Resources.MergedDictionaries[0].Source.ToString().Contains("LightBlueTheme") ? new Uri("/ThemesLibrary;component/Themes/CoralTheme.xaml", UriKind.RelativeOrAbsolute) : new Uri("/ThemesLibrary;component/Themes/LightBlueTheme.xaml", UriKind.RelativeOrAbsolute)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}