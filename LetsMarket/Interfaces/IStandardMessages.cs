namespace LetsMarket
{
    public interface IStandardMessages
    {
        void DeleteErrorMessage();
        void ListingMessage();
        bool ShowMessageAndConfirmCreate();
        bool ShowMessageAndConfirmDelete();
    }
}