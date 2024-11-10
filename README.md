# QuartzASPNetCSharp
Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icim bir ASP.NET Core uygulamasi uzerinde gelistirme yapiliyor.
Projededeki Senaryoda 3 farkli is/Job (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Zincir 1.Job ile basliyor ve her Job tamanlandiktan sonra kendisinden sonra calistirilmasi gereken Job i belirliyor .

Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu bereber implemente edildi. 

Boylelikle isler sirali calistirilir, ayni zamanda her isin baslangic, tamamlanma ve hata durumlari JobListener ile izlenip loglanir (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. 

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz
