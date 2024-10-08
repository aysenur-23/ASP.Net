# ASP.Net

- BookDemo içindeki kodlarda post, get, patch, delete vb işlemler için hazırlanmış temel bir yapı mevcut.


- Rastgele deneme değerleri üretmek için post metodna aşağıdaki gibi random değerler alacak şekilde body kısmına yazıyoruz. Sonrasında run kısmından istediğimiz iterasyon sayıısnda güncelleme iletiyoruz.
{    "id": {{$randomInt}},
    "title": "{{$randomFullName}}",
    "price": {{$randomPrice}} }
