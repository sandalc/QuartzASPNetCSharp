# QuartzASPNetCSharp
# DE

Im Projekt wurde eine ASP.NET Core Anwendung entwickelt, um die Reihenfolge der Ausführung von Aufgaben mithilfe von Quartz.NET sicherzustellen.

Im Szenario des Projekts werden drei verschiedene Aufgaben/Jobs (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) nacheinander ausgeführt. Die Kette beginnt mit dem ersten Job, und nach Abschluss eines Jobs wird der nachfolgende Job festgelegt.

Für dieses Szenario wurde eine Kombination aus JobListener und Chaining (Verkettung) implementiert.

Auf diese Weise werden die Aufgaben in der richtigen Reihenfolge ausgeführt, und gleichzeitig können der Beginn, das Ende sowie Fehlerzustände jeder Aufgabe über den JobListener überwacht und im Log (Konsole) erfasst werden.

Wenn Sie mit Quartz.NET eine Aufgabe in regelmäßigen Abständen (z. B. alle 3 Stunden) auslösen möchten, müssen Sie dafür einen Timer (Trigger) erstellen. Im Projekt finden sich Implementierungen für diesen Zweck.

Dieser Timer kann so konfiguriert werden, dass er in festgelegten Abständen mithilfe des TriggerBuilders ausgeführt wird.

Derzeit ist der erste Job, der der Hauptaufrufpunkt der miteinander verbundenen Jobkette ist, so eingestellt, dass er alle 1 Minute ausgelöst wird. Wie zu erkennen ist, wird der erste Job der geplanten Kette ausgelöst, und die anderen Jobs werden erstellt und warten auf ihren Aufruf.
# TR
Projede Quartz.NET kullanarak Islerin sirali calismasini  saglamak icin bir ASP.NET Core uygulamasi uzerinde gelistirme yapildi.

Projededeki Senaryoda 3 farkli is/Job (DbUpdateTask, ElastichIndexUpdateTask, IliskiTask) sirali sekilde calistiriliyor.
Zincir 1.Job ile basliyor ve her Job tamanlandiktan sonra kendisinden sonra calistirilmasi gereken Job i belirliyor .

Bunun icin; JobListener ve chaining (zincirleme) kombinasyonu bereber implemente edildi. 

Boylelikle isler sirali calistrilip, ayni zamanda her isin baslangic, tamamlanma ve hata durumlari JobListener ile izlenip loglanabilmekte (Console).

Eger Quartz.NET ile belirli bir aralikla (örnegin her 3 saatte bir) bir isin tetiklenmesini istiyorsaniz, bunun için bir zamanlayici (trigger) olusturmaniz gerekecek. Projede bu konuya ait uygulanmis kodlar bulunmakta.

Bu zamanlayici, TriggerBuilder kullanarak belirli bir aralikta çalisacak sekilde yapilandirabilirsiniz

Hali hazirda; birbirine bagli zincir Joblarin ilk ana giris noktasi olan 1. Job her 1 dakikada bir tetiklenecek şekilde ayarlanmiş bulunmakta. Fark edileceği uzere; aslinda zamanlanan zincirin basindaki ilk Job, diger Job lar olusturulmakta ve kendilerinin cagrilmasini beklemekte.

