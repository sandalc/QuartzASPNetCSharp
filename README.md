# QuartzASPNetCSharp
# DE

Im Projekt wurde eine ASP.NET Core-Anwendung entwickelt, um die Ausführung von Aufgaben in einer bestimmten Reihenfolge mit Quartz.NET zu ermöglichen.

Im Szenario des Projekts werden drei verschiedene Aufgaben/Jobs (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) nacheinander ausgeführt. Die Kette beginnt mit der ersten Aufgabe und nach Abschluss jeder Aufgabe wird die nächste zu ausführende Aufgabe bestimmt.

Zu diesem Zweck wurden der JobListener und die Chaining-Mechanismen gemeinsam implementiert.

Auf diese Weise werden die Aufgaben in der richtigen Reihenfolge ausgeführt, und der Beginn, das Ende sowie etwaige Fehlerzustände jeder Aufgabe können mit dem JobListener überwacht und in der Konsole (Log) protokolliert werden.

Falls Sie mit Quartz.NET eine Aufgabe in regelmäßigen Abständen (zum Beispiel alle 3 Stunden) auslösen möchten, müssen Sie einen Trigger erstellen. Auch in diesem Bereich wurde im Projekt eine entsprechende Entwicklung durchgeführt.

Derzeit sind die Aufgaben so konfiguriert, dass sie jede Minute in der festgelegten Reihenfolge ausgeführt werden.

Dieser Trigger kann mit dem TriggerBuilder so konfiguriert werden, dass er in einem bestimmten Intervall ausgeführt wird.
# TR
Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icin bir ASP.NET Core uygulamasi uzerinde gelistirme yapildi.

Projededeki Senaryoda 3 farkli is/Job (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Zincir 1.Job ile basliyor ve her Job tamanlandiktan sonra kendisinden sonra calistirilmasi gereken Job i belirliyor .

Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu bereber implemente edildi. 

Boylelikle isler sirali calistrilip, ayni zamanda her isin baslangic, tamamlanma ve hata durumlari JobListener ile izlenip loglanabilmekte (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. Projede bu konuya ait uygulanmis kodlar bulunmakta.

Şuan Joblar her 1 dakikada bir belirtilen sira ile calisabilecek sekilde ayarlanmis bulunmakta.

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz
