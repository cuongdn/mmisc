function Config() {
    // URLs to WebAPI Controllers
    this.albumsUrl = baseUrl + "/Services/MusicStore.svc/Albums";
    this.albumsWithArtistsUrl = baseUrl + "/Services/MusicStore.svc/Albums?$expand=Artist";
    this.artistsUrl = baseUrl + "/Services/MusicStore.svc/Artists";
    this.genresUrl = baseUrl + "/Services/MusicStore.svc/Genres";
    this.imagesUrl = baseUrl + "/Api/Images";
    this.salesByGenreUrl = baseUrl + "/Api/StoreSalesGenre";
    this.salesAndRevenueUrl = baseUrl + "/Api/StoreSalesRevenue";
    
    // General Settings
    this.albumDetailsWindowWidth = "400px";
    this.featuredArtist = "Metallica";
    this.bannerImages = [
        baseUrl + "/Content/Images/Feature1.png",
        baseUrl + "/Content/Images/Feature2.png",
       baseUrl + "/Content/Images/Feature3.png"
    ];
    this.browseGenrePageSize = 20;
    this.manageAlbumsGridPageSize = 50;
    this.searchMaxResults = 20;
    
    // Default values for new Albums added through management screen
    this.newAlbumDefaultGenre = 1;
    this.newAlbumDefaultArtist = 1;
    this.newAlbumDefaultPrice = 9.99;

    // functions for reading results from WCF OData service.
    this.wcfSchemaData = function (data) {
        if (data.value) {
            return data.value;
        }
        delete data["odata.metadata"];
        return [data];
    };
    this.wcfSchemaTotal = function (data) {
        return data["odata.count"];
    };
}