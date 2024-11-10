# QuartzASPNetCSharp

Im Projekt wurde eine ASP.NET Core-Anwendung entwickelt, um die Ausführung von Aufgaben in einer bestimmten Reihenfolge mit Quartz.NET zu ermöglichen.

Im Szenario des Projekts werden drei verschiedene Aufgaben/Jobs (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) nacheinander ausgeführt. Die Kette beginnt mit dem ersten Job, und nach Abschluss jedes Jobs wird der nächste Job bestimmt, der ausgeführt werden muss.

Zu diesem Zweck wurden der JobListener und die Kettenbildung (Chaining) gemeinsam implementiert.

Auf diese Weise werden die Aufgaben in der richtigen Reihenfolge ausgeführt und gleichzeitig können der Beginn, der Abschluss und etwaige Fehlerzustände jeder Aufgabe mit dem JobListener überwacht und im Log (Console) protokolliert werden.

Wenn Sie mit Quartz.NET eine Aufgabe in regelmäßigen Abständen (z. B. alle 3 Stunden) auslösen möchten, müssen Sie einen Zeitgeber (Trigger) erstellen. Eine entsprechende Anwendung ist bereits in der Produktionsumgebung vorhanden.

Derzeit sind die Jobs so konfiguriert, dass sie alle 1 Minute in der festgelegten Reihenfolge ausgeführt werden.

Dieser Zeitgeber kann mithilfe des TriggerBuilder so konfiguriert werden, dass er in einem bestimmten Intervall ausgeführt wird.


Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icim bir ASP.NET Core uygulamasi uzerinde gelistirme yapildi.


Projededeki Senaryoda 3 farkli is/Job (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Zincir 1.Job ile basliyor ve her Job tamanlandiktan sonra kendisinden sonra calistirilmasi gereken Job i belirliyor .

Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu bereber implemente edildi. 

Boylelikle isler sirali calistrilip, ayni zamanda her isin baslangic, tamamlanma ve hata durumlari JobListener ile izlenip loglanabilmekte (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. Prodede bunlara ait uygulamada bulunmakta.

Şuan Joblar her 1 dakikada bir belirtilen sira ile calisabilecek sekilde ayarlanmis bulunmakta.

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz
