# Günlük Uygulaması

Bu, basit bir günlük uygulamasıdır. Kullanıcılar günlük başlıklarını ve içeriklerini kaydedebilirler. Uygulama, JSON dosyasında verileri saklar ve daha sonra görüntülemek veya düzenlemek için kullanabilirsiniz.

## Özellikler

- Günlük başlığı ve içeriği kaydetme
- Kaydedilen günlükleri liste şeklinde görüntüleme
- Günlükleri düzenleme
- Otomatik tarih atama
- JSON dosyası üzerinde saklama

## Nasıl Kullanılır

1. Uygulamayı başlatın.
2. "Başlık" ve "İçerik" metin kutularına günlük başlığı ve içeriğini girin.
3. "Kaydet" düğmesine tıklayarak günlüğü kaydedin. Başlık boş bırakılırsa, günlüğün kaydedildiği tarih başlık olarak kullanılır.
4. Kaydedilen günlük başlıkları "Günlükler" listesinde görüntülenir. Bir günlüğü çift tıklayarak seçebilirsiniz.
5. Günlüğü düzenlemek için "Düzenle" düğmesine tıklayın. Değişiklikleri kaydetmek için "Güncelle" düğmesini kullanın.
6. "Sıfırla" düğmesi, metin kutularını temizler.

## Önemli Not

Uygulama verileri `Gunluk.json` adlı JSON dosyasında saklar. Kullandığınız platforma göre bu dosyanın nerede saklandığına dikkat edin.

## Gereksinimler

- .NET Framework 4.5 veya üstü
- Visual Studio veya benzeri bir C# IDE
