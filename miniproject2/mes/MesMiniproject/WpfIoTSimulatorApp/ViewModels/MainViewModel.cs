using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MQTTnet;
using System.IO.Packaging;
using System.Security.Permissions;
using System.Web;
using System.Windows.Media;

namespace WpfIoTSimulatorApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region 뷰와 연계되는 멤버변수/속성과 바인딩

        private string _greeting;
        // 색상표시할 변수
        private Brush _productBrush;
        private string _logText; // 로그출력


        private IMqttClient mqttClient;
        private string brokerHost;
        private string mqttTopic;



        private IMqttClient mqttClient;
        private string brokerHost;

        public MainViewModel()
        {
            Greeting = "IoT Sorting Simulator";

            // MQTT용 초기화
            brokerHost = "210.119.12.67"; // 본인 PC 아이피
            mqttClient = "pknu/sf67/data" // 스마트팩토리 토픽
            // MQTT 클라이언트 생성 및 초기화
            InitMqttClient();

        }

        private void InitMqttClient()
        {
            var mqttFactory = new MqttClientFactory();
            mqttClient = mqttFactory.CreateMqttClient();

            // MQTT 클라이언트 접속 설정
            var mqttClientOptions = new MqttClientOptionsBuilder()
                                        .WithTcpServer(brokerHost, 1883) // 포투가 기존과 다르면 포트번호도 입력 필요
                                        .WithCleanSession(true)
                                        .Build();
            // MQTT 클라이언트에 접속
            var mqttClient.ConnectedAsync += async e =>
            {
                Log
            }
        }

        #region 뷰와 연계되는 속성

        public string 

        public string Greeting
        {
            get => _greeting;
            set => SetProperty(ref _greeting, value);
        }

        // 제품 배경색 바인딩 속성
        public Brush ProductBrush
        {
            get => _productBrush;
            set => SetProperty(ref _productBrush, value);
        }

        public event Action? StartHumiRequested;
        public event Action? StartSensorCheckRequested;     // VM에서 View에 있는 이벤트를 호출

        [RelayCommand]
        public void Move()
        {
            ProductBrush = Brushes.Gray;
            StartHumiRequested?.Invoke();   // 컨테이어벨트 애니메이션 요청(View에서 처리)
        }

        [RelayCommand]
        public void Check()
        {
            StartSensorCheckRequested?.Invoke();

            // 양품불량품 판단
            Random rand = new();
            int result = rand.Next(1, 3); //1 ~ 2

            ProductBrush = result switch
            {
                1 => Brushes.Green,     // 양품
                2 => Brushes.Crimson,       // 불량
                _ => Brushes.Aqua,      // default
            };

            // MQTT로 데이터 전송
            

        }

    }
}
