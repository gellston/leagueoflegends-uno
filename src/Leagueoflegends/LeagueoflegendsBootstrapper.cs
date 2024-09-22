using Jamesnet.Core;
using Leagueoflegends.Main.UI.Views;
using Leagueoflegends.Social.UI.Views;
using Leagueoflegends.Tft.UI.Views;
using Leagueoflegends.Social.Local.ViewModels;
using Leagueoflegends.Home.UI.Views;
using Leagueoflegends.Home.Local.ViewModels;
using Leagueoflegends.Tft.Local.ViewModels;
using Leagueoflegends.Navigate.Local.ViewModels;
using Leagueoflegends.Navigate.UI.Views;
using Leagueoflegends.Support.Local.Services;
using Leagueoflegends.Navigate.Local.Services;
using Leagueoflegends.Main.Local.ViewModels;
using Leagueoflegends.Support.Local.Datas;
using Leagueoflegends.Social.Local.Datas;
using Leagueoflegends.Navigate.Local.Datas;
using Leagueoflegends.Collection.UI.Views;
using Leagueoflegends.Collection.Local.ViewModels;
using Leagueoflegends.Collection.Local.Datas;
using Leagueoflegends.Shop.UI.Views;
using Leagueoflegends.Profile.UI.Views;
using Leagueoflegends.Profile.Local.ViewModels;
using Leagueoflegends.Profile.Local.Datas;
using Leagueoflegends.Clash.UI.Views;
using Leagueoflegends.Clash.Local.ViewModels;
using Leagueoflegends.Clash.Local.Datas;
using Leagueoflegends.Tft.Local.Datas;
using Leagueoflegends.Store.UI.Views;
using Leagueoflegends.Store.Local.Datas;
namespace Leagueoflegends;

public class LeagueOfLegendsBootstrapper : AppBootstrapper
{
    protected override void RegisterViewModels(IViewModelMapper vmMapper)
    {
        vmMapper.Register<MainContent, MainContentViewModel>();
        vmMapper.Register<OptionContent, OptionContentViewModel>();
        vmMapper.Register<SocialContent, SocialContentViewModel>();
        vmMapper.Register<SubMenuContent, SubMenuContentViewModel>();
        vmMapper.Register<OptionMenuContent, OptionMenuContentViewModel>();

        vmMapper.Register<OverviewContent, OverviewContentViewModel>();
        vmMapper.Register<ChampionsContent, ChampionsContentViewModel>();
        vmMapper.Register<SkinsContent, SkinsContentViewModel>();
        vmMapper.Register<SpellsContent, SpellsContentViewModel>();
        vmMapper.Register<TftContent, TftContentViewModel>();
        vmMapper.Register<HistoryContent, HistoryContentViewModel>();
        vmMapper.Register<HubContent, HubContentViewModel>();
        vmMapper.Register<StoreChampContent, StoreChampContentViewModel>();
        vmMapper.Register<GeneralContent, GeneralContentViewModel>();
        vmMapper.Register<VoiceContent, VoiceContentViewModel>();
    }

    protected override void RegisterDependencies(IContainer container)
    {
        container.RegisterSingleton<IMenuManager, MenuManager>();

        container.RegisterSingleton<IFriendDataLoader, FriendDataLoader>();
        container.RegisterSingleton<IMenuDataLoader, MenuDataLoader>();
        container.RegisterSingleton<IChampStatsDataLoader, ChampStatsDataLoader>();
        container.RegisterSingleton<IOptionDataLoader, OptionDataLoader>();
        container.RegisterSingleton<ISkinsDataLoader, SkinsDataLoader>();
        container.RegisterSingleton<ISpellsDataLoader, SpellsDataLoader>();
        container.RegisterSingleton<IMatchHistoryDataLoader, MatchHistoryDataLoader>();
        container.RegisterSingleton<IPlayChampDataLoader, PlayChampDataLoader>();
        container.RegisterSingleton<IRecentDataLoader, RecentDataLoader>();
        container.RegisterSingleton<IScheduleDataLoader, ScheduleDataLoader>();
        container.RegisterSingleton<ITeamFightsDataLoader, TeamFightsDataLoader>();
        container.RegisterSingleton<IStoreChampDataLoader, StoreChampDataLoader>();
        
        container.RegisterSingleton<IView, MainContent>();
        container.RegisterSingleton<IView, SubMenuContent>();
        container.RegisterSingleton<IView, OptionMenuContent>();
        container.RegisterSingleton<IView, SocialContent>();

        container.RegisterSingleton<IView, OptionContent>("OptionContent");
        container.RegisterSingleton<IView, TftContent>("TftContent");
        container.RegisterSingleton<IView, ShopContent>("ShopContent");
        container.RegisterSingleton<IView, OverviewContent>("HomeOverviewContent");
        container.RegisterSingleton<IView, HubContent>("ClashHubContent");
        container.RegisterSingleton<IView, ChampionsContent>("CollectionChampionsContent");
        container.RegisterSingleton<IView, SkinsContent>("CollectionSkinsContent");
        container.RegisterSingleton<IView, SpellsContent>("CollectionSpellsContent");
        container.RegisterSingleton<IView, HistoryContent>("ProfileMatchHistoryContent");
        container.RegisterSingleton<IView, StoreChampContent>("StoreChampionsContent");
        container.RegisterSingleton<IView, GeneralContent>("GeneralContent");
        container.RegisterSingleton<IView, NoticeContent>("NoticeContent");
        container.RegisterSingleton<IView, ChatContent>("ChatContent");
        container.RegisterSingleton<IView, SoundContent>("SoundContent");
        container.RegisterSingleton<IView, VoiceContent>("VoiceContent");
        container.RegisterSingleton<IView, HotKeyContent>("HotKeyContent");
        container.RegisterSingleton<IView, VolumeContent>("VolumeContent");
    }

    protected override void LayerInitializer(IContainer container, ILayerManager layer)
    {
        IView mainContent = container.Resolve<MainContent>();
        IView socialContent = container.Resolve<SocialContent>();
        IView subMenuContent = container.Resolve<SubMenuContent>();
        IView optionMenuContent = container.Resolve<OptionMenuContent>();

        layer.Mapping("MainLayer", mainContent);
        layer.Mapping("SocialLayer", socialContent);
        layer.Mapping("SubMenuLayer", subMenuContent);
        layer.Mapping("OptionMenuLayer", optionMenuContent);
    }

    protected override void OnStartup()
    {
    }
}

