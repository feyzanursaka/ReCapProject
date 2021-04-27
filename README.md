# ReCapProject
# Projenin Konusu 
<h5>İstenilen arabayı kiralamaya yarar. 
    Kişi giriş yapmamışsa arabaların bulunduğu sayfayı (componenti) görebilir. Her arabanın detay sayfası vardır. Giriş Yapmamış olan kişi detaylara gidebilir fakat kiralama yapabilmek için giriş yapması gerekir. Kayıt Ol ve Giriş Yap sayfaları mevcuttur. Giriş yapan kişi kiralama işlemini gerçekleştirmek için findeks puanının yeterli olması gerekir. Eğer yeterliyse ödeme sayfasına yönlendirilir. Eğer Kredi Kartı mevcutsa işlem başarılı olur değilse kredi kartı eklenir ve ödeme gerçekleştirilir. Giriş yapan kişi yeni araba, marka ve renk ekleme, silme ve güncelleme işlemlerini ayrıyeten profilini güncelleme işlemini gerçekleştirebilir.</h5>
    
# Kullanılan Teknolojiler   
<ul style="list-style-type:disc">
 <li>.NET</li>
 <li>ASP.NET</li>
    <ul>
      <li>Microsoft'un web geliştirme ortamının ve bunları içeren kütüphanelerin toplandığı yapıdır.</li> 
      <li>.NET projelerindeki web projelerine verilen isimdir.</li>
      <li>Apı Restful Mimariyi destekler.</li>
      <li>Restful Mimari, geliştirdiğimiz .NET'i tanımayan bir Java uygulamasının, IOS uygulamasının vb. bizim sistemimizle iletişim kurmasını sağlayan bir ortamdır.</li>
      <li>Proje, ASP.NET.Core altyapısıyla geliştirilmiştir.</li>
    </ul> 
 <li>EntityFramework Core</li>
 <li>Autofac</li>
    <ul>
      <li>Instance üretimini sağlayan yapıdır.</li> 
    </ul> 
 <li>FluentValidation</li> 
    <ul>
      <li>Eklemek istediğin varlığı, iş kurallarına dahil etmek için bu nesnenin yapısal olarak uygun olup olmadığını kontrol etmeye yarar.</li> 
      <li>Mesela sisteme kayıt olurken min şu kadar karakter olmalı, şifre şuna uymalı gibi kurallar yani yapısal uyuma doğrulama denir.</li>
    </ul> 
 <li>MsSql</li> 
 <li><a href="https://github.com/feyzanursaka/ReCapProject-frontend">Angular for Frontend</a></li> 
</ul>

# Kullanılan Teknikler  
<ul style="list-style-type:disc">
 <li>Layered Architecture Design Pattern</li>
 <li>AOP</li>
    <ul>
      <li>Bir metodun önünde, sonunda veya hata verdiğinde çalışan kod parçacığı AOP mimarisi ile yazılır.</li> 
      <li>Autofac AOP imkanı sunuyor.</li>
      <li>Bu sayede .NET'in IoC Container'ına Autofac enjekte edilir.</li>
    </ul> 
 <li>JWT</li>
 <li>Autofac dependency resolver</li>
 <li>IOC (Inversion of control)</li> 
    <ul>
      <li>Değişimin Kontrolü</li> 
      <li>Hiçbir katman diğerini newlemez, bu işlemi IoC yapar.</li>
      <li>Mesela CarController'ın IProductService'e ihtiyacı varsa, ASP.NET, Web API IoC Container'a bakar karşılık geleni kullanır.</li>
      <li>Tüm bellekte bir tane CarManager oluşturulur. Birden fazla client gelsede hepsine aynı instance referansını verir.</li>
    </ul> 
</ul>

# Katmanlar
<p>Proje, farklı katmanlar oluşturularak Plug and Play (Tak ve Çalıştır) Sistemler şeklinde yazıldı.
<h3>1.Business</h3>
<p>Kuralların yazıldığı yerdir. Her zaman yeni bir kural gelir. Mesela Arabanın günlük kira fiyatı 0' dan büyük olmalıdır.</p>
<ul style="list-style-type:disc">
 <li>Business katmanı Entities ve Data Accesse bağımlıdır.</li>
 <li>Bu katmanda soyut olan servisler ve onların somutu olan manager classları yer alır. </li>
 <li>Bu classlar ilgili entity için CRUD operasyonlarını ve isteğe göre farklı operasyonları içerir. (getAll, getById vb.)</li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/1.PNG" width="200" height="250">
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/2.PNG" width="200" height="250">
<ul style="list-style-type:disc">
 <li>Messages içinde string mesajlar tutulur ilgili mesaj buradan çağırılır.</li> 
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/3.PNG" width="200" height="40">
 <ul style="list-style-type:disc">
    <li>Autofac/AutofacBussinessModule içinde Service istenilen durumda o service nin managerini registe eder.</li>
 <li>SingleInstance tek bir instance oluşturur. </li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/4.PNG" width="200" height="65">
 <ul style="list-style-type:disc"> 
    <li>ValidationRules/FluentValidation içerisinde ilgili entity için istenilen iş kuralı yazılır. (DailyPrice boş olamaz, DailyPrice 0 dan büyük olmalıdır gibi) </li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/5.PNG" width="200" height="190">
<h3>2.Core</h3>
<p>Ortak kodların koyulduğu katmandır ve bütün projelerde kullanılabilir. Evrensel kodları içerir.</p>
<ul style="list-style-type:disc">
 <li>Diğer katmanları referans almaz.</li>
 <li>Diğer katmanlara bağımlı değildir.</li>
 <li>Bütün projelerde kullanılabilir.</li>
 <li>Hangi katmanla ilgilenilecekse o katmanla ilgili klasör koyulur.</li>
 <li>Entityframework base hale getirilir. Data Access Katmanının yükü hafifler.</li>
 <li>Utilities/Results Klasörü işlem sonuçlarını kontrol etmeye yarar. (data, success, message)</li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/6.PNG" width="200" height="180">
<h3>3.Data Access</h3>
<p>Veriye ulaşmak için yazdığımız kodları içeren katmandır. Veriye erişim için farklı teknikler vardır. İlerde bu tekniklere yenisini eklemek veya çıkarmak istersek diğer katmanlar bundan etkilenmez.</p>
<ul style="list-style-type:disc">
 <li>İş yapan classları oluşturulurken ilk önce onun interfacesi oluşturulur.</li>
 <li>I ile başlayanlar interfacelerdir</li>
 <li>Dal (Data Access Layer)</li>
 <li>Entities katmanını kullanmak için referans vermek gerekir. Bu yüzden Data Access katmanı Entities katmanına bağımlıdır.</li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/7.PNG" width="200" height="450">
<h3>4.Entities</h3>
<p>Varlıkların yazıldığı katmandır.</p>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/8.PNG" width="200" height="350">
<h3>5.API</h3>
<p>Business ve Data Access API katmanı vasıtasıyla dış dünyaya açılır.</p>
<ul style="list-style-type:disc">
 <li>Controllers</li>
    <ul>
      <li>Gelen istekleri karşılar.</li>
      <li>Yapılabilecek istekler kodlanır.</li>
      <li>İstek Restful --> HTTP üzerinden gelir.</li>
      <li>Business katmanında yazdığımız service'leri kullanarak Http Post Get işlemleri yapılır.</li> 
    </ul> 
 <li></li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/9.PNG" width="200" height="450">
