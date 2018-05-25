# CRMP.XTBPlugin.SystemComparer
XRMToolBox Plugin to compare two systems and show differences

## Summary
If you are following a standardized deployment, you will probably not need this tool. However sometimes it happens, that the target system behaves different than the source system.
In this case it would be good to verify if there are any differences in the customizations.

This Plugin allows you to compare the EntityMetadata of two environment and check for differences.

It is based on the [CRM Comparer](https://archive.codeplex.com/?p=crmcomparer) by Thymio Barbatsis.

## How does it work
You are connecting to two Dynamics instances. The tool will fetch the EntityMetadata of both environments including the attributes.
The result is a expandable tree, showing you differences or missing objects. Compared to the original tool it is no comparing a solution only.
It is comparing the whole Metadata of the whole environment.

## Use the Plugin

First you should connect to the source environment you want to compare with. After that, find the plugin and open it.

![Find Plugin][logo01]

Connect to the second Organization by using the Button "Change Target". If both organizationnames are green, you can click "Load Metadata" in the toolbar.
Be patient. After a short time, the Metadata has been loaded and you will see the compared result and click through the tree.

![Execute Plugin][logo02]

Click on the small icons in the front of the list item, you can expand or collapse the items. If you click on the "Name" field, you can see the data-output as JSON in the screen below.

![Compare and Enjoy][logo03]

[logo01]: https://github.com/iggsn/XTBPlugin.SystemComparerer/raw/master/Documentation/01_find_plugin.png "Find Plugin"
[logo02]: https://github.com/iggsn/XTBPlugin.SystemComparerer/raw/master/Documentation/02_execute_plugin.png "Execute Plugin"
[logo03]: https://github.com/iggsn/XTBPlugin.SystemComparerer/raw/master/Documentation/03_enjoy_plugin.png "Compare and Enjoy"
