using Microsoft.EntityFrameworkCore;
using UcimoMaui.Models;

namespace UcimoMaui

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private bool IsRegistrationFormVisible = false;

        private void RegistracijaKlik(object sender, EventArgs e)
        {
            // Toggle visibility of the registration form
            IsRegistrationFormVisible = !IsRegistrationFormVisible;

            if (IsRegistrationFormVisible)
            {
                // Display the registration form
                // You can create a new layout or show/hide elements as needed
                // For this example, we'll just hide the login elements
                KorisnickoUnos.IsVisible = false;
                SifraUnos.IsVisible = false;
            }
            else
            {
                // Display the login form
                KorisnickoUnos.IsVisible = true;
                SifraUnos.IsVisible = true;
            }
        }
        private async void RegisterUser(string username, string password)
    {
        using (var db = new AppDbContext())
        {
            var existingUser = await db.Korisnici.FirstOrDefaultAsync(u => u.Korisnicko == username);
            if (existingUser != null)
            {
                await DisplayAlert("Registration Failed", "Username already taken.", "OK");
            }
            else
            {
                var newUser = new Korisnici { Korisnicko = username, Sifra = password };
                db.Korisnici.Add(newUser);
                await db.SaveChangesAsync();
                await DisplayAlert("Registration Successful", "You can now login.", "OK");
            }
        }
    }
    private void PrijavaKlik(object sender, EventArgs e)
        {
            string korisnicko = KorisnickoUnos.Text;
            string sifra = SifraUnos.Text;

            if (korisnicko == "nazezu" && sifra == "test123")
            {
                DisplayAlert("Prijava je uspješna", "Dobrodošli, " + korisnicko, "OK");
            }
            else
            {
                DisplayAlert("Prijava nije uspješna.", "Pogrešno uneseni podaci. Pokušajte ponovno", "OK");
            }
        }
    }
}