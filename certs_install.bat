chcp 65001

reg add "HKCU\Software\Microsoft\Command Processor" /v DisableUNCCheck /t REG_DWORD /d 1 /f

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uRoot -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\Root\cert_minkom.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uRoot -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\Root\cert_ufk_gol.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uRoot -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\Root\Kornevoy-sertifikat-GUTS-2022.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uRoot -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\Root\rootca_ssl_rsa2022.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uCA -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\CA\cert_ufk.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uCA -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\CA\Kaznacheystvo-Rossii.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uCA -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\CA\uts-fk_2020.cer"

"C:\Program Files\Crypto Pro\CSP\certmgr.exe" -install -store uCA -file "\\Mainserver\документы\АСУ\Иван Домашенко\РАБОТА\Сайты и системы\Закупки\ЕИС настройка\НАСТРОЙКА\CA\UTS-FK_2021.cer"


Pause