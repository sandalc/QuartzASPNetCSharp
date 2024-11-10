# QuartzASPNetCSharp
Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icim bir ASP.NET Core uygulamasi uzerinde gelistirme yapiliyor.
Projededeki Senaryoda 3  Farkli is/Jobi (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu kullanir. 

Boylelikle isler sirali calistirilir, ayni zamanda her isin baslangic, tamamlanma ve hata durumlari JobListener ile izlenip loglanir (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. 

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz
