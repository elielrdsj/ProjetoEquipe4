namespace LetsMarket.Interfaces
{
    public interface IStandardMessages
    {
        bool ShowMessageAndConfirmCreate();
        bool ShowMessageAndConfirmDelete();
        void ListingMessage();
        void DeleteErrorMessage();
    }
}
