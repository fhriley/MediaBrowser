﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using System.Linq;

namespace MediaBrowser.Server.Implementations.Collections
{
    public class ManualCollectionsFolder : BasePluginFolder
    {
        public ManualCollectionsFolder()
        {
            Name = "Collections";
            DisplayMediaType = "CollectionFolder";
        }

        public override bool IsVisible(User user)
        {
            return base.IsVisible(user) && GetChildren(user, false).Any();
        }

        public override bool IsHidden
        {
            get
            {
                return true;
            }
        }

        public override bool IsHiddenFromUser(User user)
        {
            return !user.Configuration.DisplayCollectionsView;
        }

        public override string CollectionType
        {
            get { return Model.Entities.CollectionType.BoxSets; }
        }

        public override string GetClientTypeName()
        {
            return typeof (CollectionFolder).Name;
        }
    }
}