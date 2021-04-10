using Microsoft.Win32;
using PosterWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для AppManagement.xaml
    /// </summary>
    public partial class AppManagement : Window
    {
        BdClassGet bdClassGet = new BdClassGet();
        BdClassAdd bdClassAdd = new BdClassAdd();
        BdClassDelete bdClassDelete = new BdClassDelete();
        BdClassUpdate bdClassUpdate = new BdClassUpdate();

        public AppManagement()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BdList.SelectedItem = ComboBoxFilms;
            ChangeGrid(Films);
        }

        private void BdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object grid = Films;
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            switch (selectedItem.Text)
            {
                case "Films": { grid = Films;  break; }
                case "Cinemas": { grid = Cinemas; break; }
                case "MoviesInCinemas": { grid = MoviesInCinemas; break; }
                case "Concerts": { grid = Concerts; break; }
                case "ConcertHalls": { grid = ConcertHalls; break; }
                case "ConcertsInConcertHalls": { grid = ConcertsInConcertHalls; break; }
                case "Calendar": { grid = Calendar; break; }
                case "BookedMovies": { grid = BookedMovies; break; }
                case "BookedConcerts": { grid = BookedConcerts; break; }
                case "Users": { grid = Users; break; }
            }
            
            ChangeGrid((Grid)grid);
            
            refreshFilmsBdGrid();
            refreshCinemasBdGrid();
            refreshMICBdGrid();
            refreshCalendarBdGrid();
            refreshUsersBdGrid();
            refreshBKBdGrid();
            refreshConcertsBdGrid();
            refreshConcertHallsBdGrid();
            refreshCICHBdGrid();
            refreshBCBdGrid();
        }



        /////////////////////////////////Films event ///////////////////////////////////////////////////////////
        private void Films_Loaded(object sender, RoutedEventArgs e)
        {
            refreshFilmsBdGrid();
        }
        private void FilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                string pathDescription = "../../Description/" + FilmsName.Text + ".txt";
                File.WriteAllText(pathDescription, FilmsDescription.Text);
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddFilm(FilmsBdFrid.Items.Count, FilmsName.Text, pathDescription, imagecode, FilmsGenre.Text, FilmsCountry.Text, FilmsDuration.Text);
                refreshFilmsBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FilmsSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + FilmsName.Text + ".txt";
                File.WriteAllText(pathDescription, FilmsDescription.Text);
                FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateFilm(film.Id, FilmsName.Text, pathDescription, imagecode, FilmsGenre.Text, FilmsCountry.Text, FilmsDuration.Text);
                refreshFilmsBdGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FilmsDelete_Click(object sender, RoutedEventArgs e)
        {
            if(FilmsBdFrid.SelectedItem!=null)
            {
                FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;

                bdClassDelete.DeleteRowTable(film.Id, "Films");
                string pathDescription = "../../Description/" + film.Name + ".txt";
                File.Delete(pathDescription);
                refreshFilmsBdGrid();
            }
        }

        private void FilmsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                FilmsImage.Stretch = Stretch.Fill;
                FilmsImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void FilmsBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (FilmsBdFrid.SelectedItem != null)
                {
                    FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;

                    FilmsName.Text = film.Name;
                    FilmsGenre.Text = film.Genre;
                    FilmsCountry.Text = film.Country;
                    FilmsDuration.Text = film.Duration;
                    FilmsDescription.Text = File.ReadAllText(film.DescriptionAndActors);
                    imageByte = film.Photo;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(film.Photo);
                    image.EndInit();

                    FilmsImage.Source = image;
                
                }
            }
            catch
            {
                    Console.WriteLine(e.ToString());
            }

            
        }
        ///////////////////////////////////Cinemas event ////////////////////////////////////
        private void CinemasBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CinemasBdFrid.SelectedItem != null)
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;

                CinemasName.Text = cinema.Name;
                CinemasAddress.Text = cinema.Address;
                imageByte = cinema.Photo;

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(cinema.Photo);
                image.EndInit();

                CinemasImage.Source = image;
            }
        }

        private void CinemasAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddCinema(CinemasBdFrid.Items.Count, CinemasName.Text, CinemasAddress.Text, imagecode);
                refreshCinemasBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinemasSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateCinemas(cinema.Id, CinemasName.Text, CinemasAddress.Text, imagecode);
                refreshCinemasBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinemasDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CinemasBdFrid.SelectedItem != null)
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;

                bdClassDelete.DeleteRowTable(cinema.Id, "Cinemas");
                refreshCinemasBdGrid();
            }
        }

        private void CinemasChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                CinemasImage.Stretch = Stretch.Fill;
                CinemasImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void Cinemas_Loaded(object sender, RoutedEventArgs e)
        {
            refreshCinemasBdGrid();
        }



        /////////////////////////////////////MIC event////////////////////////////////////////////////////
        private void MoviesInCinemas_Loaded(object sender, RoutedEventArgs e)
        {
            refreshMICBdGrid();
        }

        private void MICBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MICBdFrid.SelectedItem != null)
                {
                    MICClass mic = MICBdFrid.SelectedItem as MICClass;

                    MICDate.SelectedDate = mic.Date;
                    int indexFilm = FilmIdName.Items.IndexOf(mic.FilmName);
                    FilmIdName.SelectedItem = FilmIdName.Items.GetItemAt(indexFilm);
                    int indexCinema = CinemaIdName.Items.IndexOf(mic.CinemaName);
                    CinemaIdName.SelectedItem = CinemaIdName.Items.GetItemAt(indexCinema);
                    MICPrice.Text = mic.Price.ToString();
                    MICTime.Text = mic.Time;
                    MICFreeSpaces.Text = mic.FreeSpaces.ToString();
                    MICReservedSpaces.Text = mic.FreeSpaces.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MICAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                bdClassAdd.AddMIC(1, (DateTime)MICDate.SelectedDate, FilmIdName.SelectedItem.ToString(), CinemaIdName.SelectedItem.ToString(), Int32.Parse(MICPrice.Text), MICTime.Text, Int32.Parse(MICFreeSpaces.Text), Int32.Parse(MICReservedSpaces.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
        }

        private void MICSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MICClass mic = MICBdFrid.SelectedItem as MICClass;
                bdClassUpdate.UpdateMIC(mic.Id, (DateTime)MICDate.SelectedDate, FilmIdName.SelectedItem.ToString(), CinemaIdName.SelectedItem.ToString(), Int32.Parse(MICPrice.Text), MICTime.Text, Int32.Parse(MICFreeSpaces.Text), Int32.Parse(MICReservedSpaces.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
            
        }

        private void MICDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MICBdFrid.SelectedItem != null)
                {
                    MICClass mic = MICBdFrid.SelectedItem as MICClass;

                    bdClassDelete.DeleteRowTable(mic.Id, "MIC");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
            
        }


        /////////////////////////////////////Calendar event/////////////////////////////////////////////////////
        private void CalendarAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddDate(1, (DateTime)CalendarDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;
                bdClassUpdate.UpdateDate(calendarClass.Id, (DateTime)CalendarDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CalendarBdFrid.SelectedItem != null)
                {
                    CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;

                    bdClassDelete.DeleteRowTable(calendarClass.Id, "Calendar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CalendarBdFrid.SelectedItem != null)
                {
                    CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;
                    CalendarDate.SelectedDate = calendarClass.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            refreshCalendarBdGrid();
        }

        ///////////////////////////////////////Users event///////////////////////////////////////
        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            refreshUsersBdGrid();
        }

        private void UsersBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (UsersBdGrid.SelectedItem != null)
                {
                    UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;

                    UsersName.Text = usersClass.Name;
                    UsersMail.Text = usersClass.Mail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsersAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddUser(1, UsersMail.Text, UsersName.Text, User.HashPassword(UsersPassword.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        private void UsersSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;
                bdClassUpdate.UpdateUser(usersClass.Id, UsersMail.Text, UsersName.Text, User.HashPassword(UsersPassword.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        private void UsersDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersBdGrid.SelectedItem != null)
                {
                    UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;

                    bdClassDelete.DeleteRowTable(usersClass.Id, "User");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        ////////////////////////////////BookedMovies//////////////////////////////////////////////////
        private void BookedMoviesBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BookedMoviesBdGrid.SelectedItem != null)
                {
                    BMClass bKClass = BookedMoviesBdGrid.SelectedItem as BMClass;

                    int indexFilms = BMIdName.Items.IndexOf(bKClass.Film);
                    BMIdName.SelectedItem = BMIdName.Items.GetItemAt(indexFilms);

                    int indexUser = BCUserIdName.Items.IndexOf(bKClass.UserMail);
                    BMUserIdName.SelectedItem = BMUserIdName.Items.GetItemAt(indexUser);

                    BKDate.SelectedDate = bKClass.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookedMovies_Loaded(object sender, RoutedEventArgs e)
        {
            refreshBKBdGrid();
        }

        private void BKAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddBM(1, BMUserIdName.SelectedItem.ToString(), BMIdName.SelectedItem.ToString(), (DateTime)BKDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        private void BKSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BMClass bkClass = BookedMoviesBdGrid.SelectedItem as BMClass;
                bdClassUpdate.UpdateBK(bkClass.Id, BMUserIdName.SelectedItem.ToString(), BMIdName.SelectedItem.ToString(), (DateTime)BKDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        private void BKDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BookedMoviesBdGrid.SelectedItem != null)
                {
                    BMClass bKClass = BookedMoviesBdGrid.SelectedItem as BMClass;

                    bdClassDelete.DeleteRowTable(bKClass.Id, "BK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        ///////////////////////////////////Concerts event //////////////////////////////////////////////
        private void ConcertsBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ConcertsBdGrid.SelectedItem != null)
                {
                    ConcertsClass concertsClass = ConcertsBdGrid.SelectedItem as ConcertsClass;

                    ConcertsName.Text = concertsClass.Name;
                    ConcertsGenre.Text = concertsClass.Genre;
                    ConcertsTime.Text = concertsClass.Time;
                    ConcertsDescription.Text = File.ReadAllText(concertsClass.Description);
                    imageByte = concertsClass.Photo;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(concertsClass.Photo);
                    image.EndInit();

                    ConcertsImage.Source = image;

                }
            }
            catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void Concerts_Loaded(object sender, RoutedEventArgs e)
        {
            refreshConcertsBdGrid();
        }

        private void ConcertsAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + ConcertsName.Text + "C" + ".txt";
                File.WriteAllText(pathDescription, ConcertsDescription.Text);
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddConcerts(1, ConcertsName.Text, pathDescription, ConcertsTime.Text, imagecode, ConcertsGenre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void CocnertsSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + FilmsName.Text + "C" + ".txt";
                File.WriteAllText(pathDescription, ConcertsDescription.Text);
                ConcertsClass concertsClass = ConcertsBdGrid.SelectedItem as ConcertsClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateConcerts(concertsClass.Id, ConcertsName.Text, pathDescription, ConcertsTime.Text, imagecode, ConcertsGenre.Text);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void ConcertsDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ConcertsBdGrid.SelectedItem != null)
                {
                    ConcertsClass concerts = ConcertsBdGrid.SelectedItem as ConcertsClass;

                    bdClassDelete.DeleteRowTable(concerts.Id, "Concerts");
                    string pathDescription = "../../Description/" + concerts.Name + "C" + ".txt";
                    File.Delete(pathDescription);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void ConcertsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                ConcertsImage.Stretch = Stretch.Fill;
                ConcertsImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }


        /////////////////////////////////////////ConcertHalls event//////////////////////////////////
        private void ConcertHallsBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ConcertHallsBdGrid.SelectedItem != null)
                {
                    ConcertHallsClass concertHalls = ConcertHallsBdGrid.SelectedItem as ConcertHallsClass;

                    ConcertHallsName.Text = concertHalls.Name;
                    ConcertHallsAddress.Text = concertHalls.Address;
                    imageByte = concertHalls.Photo;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(concertHalls.Photo);
                    image.EndInit();

                    ConcertHallsImage.Source = image;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConcertHallsAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddConcertHalls(1, ConcertHallsName.Text, ConcertHallsAddress.Text, imagecode);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertHallsBdGrid();
            }
        }

        private void CocnertHallsSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConcertHallsClass concertHalls = ConcertHallsBdGrid.SelectedItem as ConcertHallsClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateConcertHalls(concertHalls.Id, ConcertHallsName.Text, ConcertHallsAddress.Text, imagecode);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertHallsBdGrid();
            }
        }

        private void ConcertHallsDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ConcertHallsBdGrid.SelectedItem != null)
                {
                    ConcertHallsClass concertHalls = ConcertHallsBdGrid.SelectedItem as ConcertHallsClass;

                    bdClassDelete.DeleteRowTable(concertHalls.Id, "ConcertHalls");
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertHallsBdGrid();
            }
        }

        private void ConcertHallsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                ConcertHallsImage.Stretch = Stretch.Fill;
                ConcertHallsImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void ConcertHalls_Loaded(object sender, RoutedEventArgs e)
        {
            refreshConcertHallsBdGrid();
        }

        /////////////////////////////////////CICH event/////////////////////////////////////////////////////////
        private void ConcertsInConcertHalls_Loaded(object sender, RoutedEventArgs e)
        {
            refreshCICHBdGrid();
        }

        private void CICHDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CICHBdGrid.SelectedItem != null)
                {
                    CICHClass cich = CICHBdGrid.SelectedItem as CICHClass;

                    bdClassDelete.DeleteRowTable(cich.Id, "CICH");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCICHBdGrid();
            }
        }

        private void CICHSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CICHClass cich = CICHBdGrid.SelectedItem as CICHClass;
                bdClassUpdate.UpdateCICH(cich.Id, (DateTime)CICHDate.SelectedDate, ConcertsIdName.SelectedItem.ToString(), ConcertHallsIdName.SelectedItem.ToString(), Int32.Parse(CICHPrice.Text), Int32.Parse(CICHFreeSpaces.Text), Int32.Parse(CICHReservedSpaces.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCICHBdGrid();
            }
        }

        private void CICHAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddCICH(1, (DateTime)CICHDate.SelectedDate, ConcertsIdName.SelectedItem.ToString(), ConcertHallsIdName.SelectedItem.ToString(), Int32.Parse(CICHPrice.Text), Int32.Parse(CICHFreeSpaces.Text), Int32.Parse(CICHReservedSpaces.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCICHBdGrid();
            }
        }

        private void CICHBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CICHBdGrid.SelectedItem != null)
                {
                    CICHClass cich = CICHBdGrid.SelectedItem as CICHClass;

                    CICHDate.SelectedDate = cich.Date;

                    int indexConcerts = ConcertsIdName.Items.IndexOf(cich.ConcertsName);
                    ConcertsIdName.SelectedItem = ConcertsIdName.Items.GetItemAt(indexConcerts);
                    int indexConcertHalls = ConcertHallsIdName.Items.IndexOf(cich.ConcertHallsName);
                    ConcertHallsIdName.SelectedItem = ConcertHallsIdName.Items.GetItemAt(indexConcertHalls);

                    CICHPrice.Text = cich.Price.ToString();
                    CICHFreeSpaces.Text = cich.FreeSpaces.ToString();
                    CICHReservedSpaces.Text = cich.FreeSpaces.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
       
        ///////////////////////////////////////BookedConcerts event//////////////////////////////////////////////////////////////
        private void BookedConcerts_Loaded(object sender, RoutedEventArgs e)
        {
            refreshBCBdGrid();
        }

        private void BCBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BCBdGrid.SelectedItem != null)
                {
                    BCClass bCClass = BCBdGrid.SelectedItem as BCClass;

                    int indexConcerts = BCIdName.Items.IndexOf(bCClass.Concert);
                    BCIdName.SelectedItem = BCIdName.Items.GetItemAt(indexConcerts);

                    int indexUser = BCUserIdName.Items.IndexOf(bCClass.UserMail);
                    BCUserIdName.SelectedItem = BCUserIdName.Items.GetItemAt(indexUser);

                    BCDate.SelectedDate = bCClass.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BCAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddBC(1, BCUserIdName.SelectedItem.ToString(), BCIdName.SelectedItem.ToString(), (DateTime)BCDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBCBdGrid();
            }
        }

        private void BCSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BCClass bCClass = BCBdGrid.SelectedItem as BCClass;
                bdClassUpdate.UpdateBC(bCClass.Id, BCUserIdName.SelectedItem.ToString(), BCIdName.SelectedItem.ToString(), (DateTime)BCDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBCBdGrid();
            }
        }

        private void BCDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BCBdGrid.SelectedItem != null)
                {
                    BCClass bCClass = BCBdGrid.SelectedItem as BCClass;

                    bdClassDelete.DeleteRowTable(bCClass.Id, "BC");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBCBdGrid();
            }
        }




    }
}
