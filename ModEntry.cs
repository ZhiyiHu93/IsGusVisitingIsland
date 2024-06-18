using ContentPatcher;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;


namespace IsGusVisitingIsland
{
    public class ModEntry
    : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += GameLaunched;
        }

        private void GameLaunched(object sender, GameLaunchedEventArgs e)
        {
            var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            if (api != null)
                api.RegisterToken(this.ModManifest, "IsVisiting", ()=>{
                    if (Context.IsWorldReady){
                        return new[] { Game1.IsVisitingIslandToday("Gus").ToString().ToLower() };
                    }
                    if (SaveGame.loaded?.player != null){
                        return new[] { Game1.IsVisitingIslandToday("Gus").ToString().ToLower() };
                    }
                    return new[] { "false" };
                });   
        }

    }
}