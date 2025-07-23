#include <QCoreApplication>

// ============ВЫБОР МИКРОСХЕМЫ============================
// логические переменные для обозначения выбора микросхемы
bool isDualChannelAmplifier = false; // без смещения
bool isTripleChannelAmplifier = false; // со смещением

//=============ВЫБОР ПРИБОРОВ=============================
//(плюс выбор диапазона или списка параметров, флаг?)

// переменные для камеры тепла и холода
bool thermalCameraOn = false;
// переменные для мультиметра
bool ammeterOn = false;
// переменные для источника питания(не надо?)
bool powerSupplyOn = true;
// переменные для векторного анализатора
bool vnaOn = false;

//============РАБОТА ИСТОЧНИКА ПИТАНИЯ =====================
short int vc_power_supply; // выбор типа источника питания для напряжения питания (1-одноканальный; 2-двухканальный; 3-канальный)
short int vg_power_supply; // выбор типа источника питания для напряжения смещения (1-одноканальный; 2-двухканальный; 3-канальный)
//short int control_power_supply; // выбор типа источника питания для управляющего сигнала

short int vc_output_number;// выбор номера канала для подключения питания
short int vg_output_number; // выбор номера канала для подключения смещения
//short int control_signal; // выбор номера канала для управляющего сигнала

float u_supply_start; // напряжения питания
float u_supply_stop;
float u_supply_step;
float limit_i_supply = 0.5; // лимит тока питания в А

float u_offset; // найденное напряжение смещения
//float u_offset_start = 1;
//float u_offset_min = 0.4; // если уже равен 0,4 А завершаем работу
float limit_i_offset = 0.02; // лимит тока смещения (на микросхеме) в А

std::string file_path; // путь сохранения ВАХ-характеристики
std::string file_name; // имя файла для сохранения .txt

// подумать над этим
std::string file_path_apply_settings; // применение настроек из файла по необходимому напряжению питания

// ===========РАБОТА ВЕКТОРНОГО АНАЛИЗАТОРА ================
double start_power;
double stop_power;
double start_freq;
double stop_freq;
int points;
double main_freq;

double start_amp = 0;
double amp_difference = 1.0;
double best_diff = 1e5;
int best_pow = 0;

std::string calibration_path;
std::string snp_path;
std::string kalls_path;
std::string result_path;

std::string amp_diff_file;
double amp_diff_power = 0;



int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    // Set up code that uses the Qt event loop here.
    // Call a.quit() or a.exit() to quit the application.
    // A not very useful example would be including
    // #include <QTimer>
    // near the top of the file and calling
    // QTimer::singleShot(5000, &a, &QCoreApplication::quit);
    // which quits the application after 5 seconds.

    // If you do not need a running Qt event loop, remove the call
    // to a.exec() or use the Non-Qt Plain C++ Application template.

    return a.exec();
}
