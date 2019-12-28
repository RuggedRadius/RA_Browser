using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Connection
{
    internal static class Constants
    {
        internal const string BASE_URL = "https://ra.hfc-essentials.com/";

        internal struct QueryTypes
        {
            // Web API
            internal const string WEB_TOP_TEN_USERS = "top_ten.php";
            internal const string WEB_CONSOLE_IDs = "console_id.php";
            internal const string WEB_GAME_LIST = "game_list.php";
            internal const string WEB_GAME_INFO_BASIC = "game_info.php";
            internal const string WEB_GAME_INFO_EXTENDED = "game_info_extended.php";
            internal const string WEB_GAME_INFO_AND_PROGRESS = "game_progress.php";
            internal const string WEB_USER_RANK_AND_SCORE = "user_rank.php";
            internal const string WEB_USER_RECENTLY_PLAYED_GAMES = "user_recent.php";
            internal const string WEB_USER_PROGRESS = "user_progress.php";
            internal const string WEB_USER_SUMMARY = "user_summary.php";
            internal const string WEB_USER_FEED = "user_feed.php";
            internal const string WEB_USER_ACHIEVEMENTS_BY_DATE = "user_by_date.php";
            internal const string WEB_USER_USER_ACHIEVEMENTS_BY_DATE_RANGE = "user_by_date.php";

            // API
            //internal const string METHOD_GET_TOP_TEN_USERS = "API_GetTopTenUsers.php";
            //internal const string METHOD_GET_USER_RANK_AND_SCORE = "API_GetUserRankAndScore.php";
            //internal const string METHOD_GET_USER_RECENTLY_PLAYED_GAMES = "API_GetUserRecentlyPlayedGames.php";
            //internal const string METHOD_GET_GAME_INFO_AND_USER_PROGRESS = "API_GetGameInfoAndUserProgress.php";
        }

        internal struct BaseURLs
        {
            // Web API
            internal const string RA_WEBAPI_BASE_URL = "http://retroachievements.org/API/";

            // Web pages
            internal const string PAGE_GAME = "https://retroachievements.org/game/{0}";
            internal const string PAGE_ACHIEVEMENT = "https://retroachievements.org/achievement/{0}";

            // Badge image locations
            internal const string BADGE_IMAGE_UNLOCKED = "http://retroachievements.org/Badge/{0}.png";
            internal const string BADGE_IMAGE_LOCKED = "http://retroachievements.org/Badge/{0}_lock.png";

            // Game Images
            internal const string GAME_IMAGES_URL_BASE = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";

        }
    }
}
