# LunaAssessment

Projeyi çalıştırmak için öncelikle database bağlantısını sağlamalısınız.
Projede iki adet database kullanılmıştır. Sayaç mikroservisi ve rapor mikroservisi için ayrı ayrı database kullanılmıştır.
Her iki mikroservisin database bağlantısını düzenlemek için;
LunaAssessment çözümü altında bulunan **microservices->metermicroservice(reportmicroservice)->infrastructure->concrete->entityframework->context->AppDbContext**
Sınıfındaki connection stringi düzenlemelisiniz.

Daha sonra database tabloları oluşturmak için migration yapısını kullanmalısınız.
Proje içinde initial-migration olduğu için migration update yapmmanız yeterli olacaktır.
**dotnet ef database update**  komutunu kullanabilirsiniz.
Bu komutu terminalde **..LunaAssessment\Microservices\MeterMicroservice\MeterMicroservice.Infrastructure>** ve **LunaAssessment\Microservices\MeterMicroservice\ReportMicroservice.Infrastructure>**
pathlerinde çalıştırarak migration update yapabilirsiniz.

Proje multiple startup olarak ayarlanmıştır. Eğer bilgisayarınızda bu şekilde konfigüre edilmiş olarak açılmaz ise property page sayfasından 
common properties->startup properties sekmesine giderek multiple seçeneğini işaretlemeli ve metermicroservice.API ve ReportMicroservice.API actionlarını start olarak değiştirmelisiniz.

Bu şekilde projenin backend kısmı iki api şeklinde ayağa kalkacaktır.

Teşekkür ederim.
