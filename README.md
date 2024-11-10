# QuartzASPNetCSharp
Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icim bir ASP.NET Core uygulamasi uzerinde gelistirme yapiliyor.
Projededeki Senaryoda 3  Farkli is/Jobi (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu kullan?r. Boylelikler isler sirali calistirilir, ayni zamanda her isin ba?langic, tamamlanma ve hata durumlari JobListener ile izlenip loglanacak (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. 

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz
