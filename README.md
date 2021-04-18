# ReCapProject
# KATMANLAR
<p>Proje, farklı katmanlar oluşturularak Plug and Play (Tak ve Çalıştır) Sistemler şeklinde yazıldı.
<h3>1.Business</h3>
<p>Kuralların yazıldığı yerdir. Her zaman yeni bir kural gelir. Mesela Arabanın günlük kira fiyatı 0' dan büyük olmalıdır.</p>
<h3>2.Core</h3>
<p>Ortak kodların koyulduğu katmandır ve bütün projelerde kullanılabilir. Evrensel kodları içerir.</p>
<h3>3.Data Access</h3>
<p>Veriye ulaşmak için yazdığımız kodları içeren katmandır. Veriye erişim için farklı teknikler vardır. İlerde bu tekniklere yenisini eklemek veya çıkarmak istersek diğer katmanlar bundan etkilenmez.</p>
<h3>4.Entities</h3>
<p>Varlıkların yazıldığı yerdir.</p>
<h3>5.API</h3>
<p>Business ve Data Access API katmanı vasıtasıyla dış dünyaya açılır.</p>
