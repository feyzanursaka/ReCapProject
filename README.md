# ReCapProject
# Projenin Konusu 
<h5>İstenilen arabayı kiralamaya yarar. 
    Kişi giriş yapmamışsa arabaların bulunduğu sayfayı (componenti) görebilir. Her arabanın detay sayfası vardır. Giriş Yapmamış olan kişi detaylara gidebilir fakat kiralama yapabilmek için giriş yapması gerekir. Kayıt Ol ve Giriş Yap sayfaları mevcuttur. Giriş yapan kişi kiralama işlemini gerçekleştirmek için findeks puanının yeterli olması gerekir. Eğer yeterliyse ödeme sayfasına yönlendirilir. Eğer Kredi Kartı mevcutsa işlem başarılı olur değilse kredi kartı eklenir ve ödeme gerçekleştirilir. Giriş yapan kişi yeni araba, marka ve renk ekleme, silme ve güncelleme işlemlerini ayrıyeten profilini güncelleme işlemini gerçekleştirebilir.</h5>
    
# KATMANLAR
<p>Proje, farklı katmanlar oluşturularak Plug and Play (Tak ve Çalıştır) Sistemler şeklinde yazıldı.
<h3>1.Business</h3>
<p>Kuralların yazıldığı yerdir. Her zaman yeni bir kural gelir. Mesela Arabanın günlük kira fiyatı 0' dan büyük olmalıdır.</p>
<ul style="list-style-type:disc">
 <li>Business katmanı Entities ve Data Accesse bağımlıdır.</li>
 <li>Bu katmanda soyut olan servisler ve onların somutu olan manager classları yer alır. </li>
 <li>Bu classlar ilgili entity için CRUD operasyonlarını ve isteğe göre farklı operasyonları içerir. (getAll, getById vb.)</li>
 <li>Autofac/AutofacBussinessModule içinde Service istenilen durumda o service nin managerini registe eder.</li>
 <li>SingleInstance tek bir instance oluşturur. </li>
 <li>ValidationRules/FluentValidation içerisinde ilgili entity için istenilen iş kuralı yazılır. (DailyPrice boş olamaz, DailyPrice 0 dan büyük olmalıdır gibi) </li>
</ul>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/1.PNG" width="200" height="250">
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/2.PNG" width="200" height="250">
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/3.PNG" width="200" height="40">
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/4.PNG" width="200" height="65">
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/5.PNG" width="200" height="190">
<h3>2.Core</h3>
<p>Ortak kodların koyulduğu katmandır ve bütün projelerde kullanılabilir. Evrensel kodları içerir.</p>
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
<p>Varlıkların yazıldığı yerdir.</p>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/8.PNG" width="200" height="350">
<h3>5.API</h3>
<p>Business ve Data Access API katmanı vasıtasıyla dış dünyaya açılır.</p>
<img src="https://github.com/feyzanursaka/ReCapProject/blob/master/projectImages/9.PNG" width="200" height="450">
