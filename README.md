LexicalAnalyzer
LexicalAnalyzer, C# dili ile geliştirilmiş bir leksik analiz (tokenizer) aracıdır. Bu proje, temel olarak bir kaynak kod dosyasını alıp içerisindeki dil öğelerini (token) tanımlar ve sınıflandırır. Derleyici tasarımı ve programlama dilleri üzerinde çalışma yapmak isteyenler için eğitim amaçlı olarak hazırlanmıştır.


🚀 Proje Özeti
-Adı: LexicalAnalyzer

-Programlama Dili: C#

-Türü: Windows Forms Uygulaması (GUI)

-Amaç: Kaynak kodu analiz ederek, lexeme ve token’ları tespit etmek ve kullanıcıya görsel olarak sunmak.


🛠️ Ana Dosyalar ve İşlevleri
-LexicalAnalyzer.cs → Kaynak kodun analiz edildiği ana sınıf.

-Token.cs → Token nesnesi ve özelliklerini tanımlar (tip, satır, kolon gibi).

-keywords.csv → Desteklenen anahtar kelimelerin listesi.

-Form1.cs → Kullanıcı arayüzü, verilerin DataGridView üzerinden gösterilmesini sağlar.

-Program.cs → Uygulamanın giriş noktası.


📌 Ne İşe Yarar?
LexicalAnalyzer, bir programlama dilinin temel sözdizimi öğelerini tanıyabilir. Örneğin:

-Anahtar kelimeler (if, for, while)

-Operatörler (+, -, *, /)

-Sabitler ve değişkenler

-Yorum satırları

Bu sayede öğrenci veya geliştirici, kaynak kodu adım adım analiz edebilir ve derleyici geliştirme sürecinde önemli bir adım olan lexical analysis kısmını pratik olarak görebilir.
