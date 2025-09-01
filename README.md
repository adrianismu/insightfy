# 📊 Insightify - Dashboard Analitik Berita

![Insightify Logo](https://img.shields.io/badge/Insightify-Dashboard%20Analitik-blue?style=for-the-badge&logo=chart-line)

**Insightify** adalah aplikasi web dashboard analitik yang modern dan responsif untuk menganalisis berita terkini dari berbagai sumber media internasional. Aplikasi ini mengintegrasikan data real-time dari NewsAPI.org dan menyajikannya dalam bentuk visualisasi interaktif yang mudah dipahami.

## 🚀 Fitur Utama

- **📰 Berita Real-time**: Mengambil berita terkini dari NewsAPI.org
- **🌍 Multi-negara**: Mendukung berita dari 10+ negara
- **📂 Kategori Beragam**: 7 kategori berita (Technology, Business, Health, dll.)
- **📊 Visualisasi Data**: Pie chart interaktif menggunakan Chart.js
- **🔍 Filter Dinamis**: Filter berdasarkan negara dan kategori
- **📱 Responsive Design**: Antarmuka yang optimal di semua perangkat
- **🔐 Keamanan API**: API key disimpan dengan aman menggunakan User Secrets

## 🖼️ Screenshot Aplikasi

### Dashboard Utama

<img width="1893" height="682" alt="image" src="https://github.com/user-attachments/assets/1657d237-8df6-41ca-b582-b50c51cdfe83" />

<img width="1886" height="898" alt="image" src="https://github.com/user-attachments/assets/d4834776-6385-4a6c-88ae-2eac51a52ff1" />


*Dashboard menampilkan filter, grafik distribusi sumber berita, dan daftar artikel terkini*

### Grafik Analitik
<img width="1880" height="612" alt="image" src="https://github.com/user-attachments/assets/d1a9a4e4-5bb8-43c2-afc6-9d636180f95b" />

*Pie chart yang menunjukkan distribusi berita berdasarkan sumber media*

## 🛠️ Teknologi yang Digunakan

### Backend
- **ASP.NET Core 8.0** - Framework web modern dan performa tinggi
- **C# 12** - Bahasa pemrograman utama
- **HTTP Client Factory** - Untuk konsumsi API eksternal
- **User Secrets** - Manajemen konfigurasi yang aman
- **Dependency Injection** - Arsitektur yang modular dan testable

### Frontend
- **Bootstrap 5** - Framework CSS untuk responsive design
- **Chart.js** - Library untuk visualisasi data interaktif
- **FontAwesome** - Icon pack untuk UI yang menarik
- **Razor Pages** - Template engine untuk dynamic content

### External APIs
- **NewsAPI.org** - Sumber data berita real-time
- **CDN Libraries** - Chart.js dan FontAwesome dari CDN

### Arsitektur
- **MVC Pattern** - Model-View-Controller untuk separation of concerns
- **Repository Pattern** - Service layer untuk business logic
- **DTO Pattern** - Data Transfer Objects untuk API communication

## 📋 Prasyarat

Sebelum menjalankan aplikasi, pastikan Anda memiliki:

- **.NET 8 SDK** - [Download di sini](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Git** - [Download di sini](https://git-scm.com/)
- **NewsAPI Key** - [Daftar gratis di NewsAPI.org](https://newsapi.org/)
- **Text Editor/IDE** - VS Code, Visual Studio, atau Rider

## 🚀 Cara Menjalankan Proyek

### 1. Clone Repository
```bash
git clone https://github.com/adrianismu/insightfy.git
cd insightfy/Insightify
```

### 2. Setup User Secrets
```bash
# Inisialisasi user secrets
dotnet user-secrets init

# Set API key (ganti YOUR_API_KEY dengan key Anda)
dotnet user-secrets set "NewsApiKey" "YOUR_API_KEY"
```

### 3. Restore Dependencies
```bash
dotnet restore
```

### 4. Build Aplikasi
```bash
dotnet build
```

### 5. Jalankan Aplikasi
```bash
dotnet run
```

### 6. Akses Aplikasi
Buka browser dan navigasi ke: `http://localhost:5020`

## 🔧 Konfigurasi

### Mendapatkan NewsAPI Key

1. Kunjungi [NewsAPI.org](https://newsapi.org/)
2. Klik "Get API Key" dan daftar akun gratis
3. Verifikasi email Anda
4. Copy API key dari dashboard
5. Gunakan perintah user-secrets di atas untuk menyimpan key

### Environment Variables

Aplikasi menggunakan .NET User Secrets untuk development. Untuk production, set environment variable:

```bash
# Linux/Mac
export NewsApiKey="your-api-key-here"

# Windows
set NewsApiKey=your-api-key-here
```

## 📁 Struktur Proyek

```
Insightify/
├── Controllers/
│   ├── DashboardController.cs    # Main dashboard logic
│   └── HomeController.cs         # Home page controller
├── Models/
│   ├── DTOs/                     # Data Transfer Objects
│   │   ├── ArticleDto.cs         # Article model
│   │   ├── NewsApiResponse.cs    # API response model
│   │   └── SourceDto.cs          # News source model
│   └── ErrorViewModel.cs         # Error handling model
├── Services/
│   ├── INewsApiService.cs        # Service interface
│   └── NewsApiService.cs         # NewsAPI integration
├── ViewModels/
│   └── DashboardViewModel.cs     # Dashboard view model
├── Views/
│   ├── Dashboard/
│   │   └── Index.cshtml          # Main dashboard view
│   ├── Home/
│   └── Shared/
│       └── _Layout.cshtml        # Layout template
├── wwwroot/                      # Static files
├── Program.cs                    # Application startup
└── appsettings.json             # Configuration
```

## 🌟 Fitur Detail

### Filter Berita
- **Negara**: Indonesia, US, UK, Australia, Canada, Germany, France, Japan, Korea, Singapore
- **Kategori**: Business, Entertainment, General, Health, Science, Sports, Technology

### Analitik Visual
- **Pie Chart**: Distribusi artikel berdasarkan sumber media
- **Real-time Update**: Data ter-update setiap kali filter berubah
- **Interactive Legend**: Klik legend untuk hide/show data

### Responsive Design
- **Mobile First**: Optimized untuk perangkat mobile
- **Bootstrap Grid**: Layout yang fleksibel
- **Touch Friendly**: UI yang mudah digunakan di touchscreen

## 🚀 Deployment

### Local Development
```bash
dotnet run --environment Development
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

### Azure App Service
1. Create Azure App Service
2. Set `NewsApiKey` di Application Settings
3. Deploy menggunakan Azure CLI atau Visual Studio

### Docker (Opsional)
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Insightify.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insightify.dll"]
```

## 🧪 Testing

### Unit Testing
```bash
# Jalankan unit tests (jika ada)
dotnet test
```

### Manual Testing
1. Test filter negara dan kategori
2. Verify data loading dari NewsAPI
3. Check responsive design di berbagai screen size
4. Validate chart rendering dan interactivity

## 🤝 Contributing

Kontribusi sangat diterima! Ikuti langkah berikut:

1. Fork repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 👨‍💻 Author

**Adrian Ismu**
- GitHub: [@adrianismu](https://github.com/adrianismu)
- Email: your.email@example.com

## 🙏 Acknowledgments

- [NewsAPI.org](https://newsapi.org/) - Untuk API berita gratis
- [Chart.js](https://www.chartjs.org/) - Library visualisasi data
- [Bootstrap](https://getbootstrap.com/) - CSS framework
- [FontAwesome](https://fontawesome.com/) - Icon library
- [Microsoft](https://docs.microsoft.com/aspnet/core/) - ASP.NET Core documentation

## 📈 Roadmap

### v2.0 (Future Updates)
- [ ] User authentication dan personalisasi
- [ ] Bookmark artikel favorit
- [ ] Export data ke PDF/Excel
- [ ] Real-time notifications
- [ ] Dark mode theme
- [ ] Multiple language support
- [ ] Advanced analytics dashboard
- [ ] Social media integration

---

**⭐ Jika proyek ini membantu Anda, berikan star di GitHub!**

![Made with Love](https://img.shields.io/badge/Made%20with-❤️-red)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0-blue)
![Chart.js](https://img.shields.io/badge/Chart.js-4.0-orange)
