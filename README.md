## Proje içeriği 
### Projemizde cache, hangfire kullanıldı. Verilen api üzerinden bilgileri 5 saniyede bir çeken bir sistem kuruldu. 

## Hangfire Nedir?
### Hangfire,background processing işlemlerini yürütmemiz de ve yönetmemiz de bizlere kolaylık sağlayan open source bir kütüphanedir.

## Hangfire Job Çeşitleri
### Hangfire Job işlemlerini temelde 2 başlık altında toplayabiliriz.Yalnızca 1 kez çalışacak işlemler ve bir rutin halinde devam edecek işlemler şeklinde.

### Yalnızca 1 kez gerçekleşecek işlemler

var jobId = BackgroundJob.Enqueue(
    () => Console.WriteLine("Fire-and-forget!"));

### İleri tarihli kullanımı.

var jobId = BackgroundJob.Schedule(
    () => Console.WriteLine("Delayed!"),
    TimeSpan.FromDays(7));

###Tekrarlanan işlemler

RecurringJob.AddOrUpdate(
    () => Console.WriteLine("Recurring!"),
    Cron.Daily);

### İşlem bitişlerin de kullanımı.Ör: bir işlem bitiminde farklı bir process in tetiklenmesi.

BackgroundJob.ContinueWith(
    jobId,
    () => Console.WriteLine("Continuation!"));
    
### Proje içeriğinde RecurringJob kullanıldı. 5 saniyede bir verilen API üerinden bilgiler çekilmektedir.
