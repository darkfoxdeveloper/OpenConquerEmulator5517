CREATE TABLE `account` (
  `id` bigint(12) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL DEFAULT '',
  `password` varchar(128) NOT NULL DEFAULT '',
  `netbar_ip` varchar(15) NOT NULL DEFAULT '',
  `create_date` int(4) unsigned NOT NULL DEFAULT '0',
  `first_login` int(4) unsigned NOT NULL DEFAULT '0',
  `account_id` int(4) unsigned NOT NULL DEFAULT '0',
  `last_login` int(4) NOT NULL DEFAULT '0',
  `lock` tinyint(1) NOT NULL DEFAULT '0',
  `vip` int(4) unsigned NOT NULL DEFAULT '1',
  `type` int(4) NOT NULL DEFAULT '2',
  `referrer` int(4) unsigned NOT NULL DEFAULT '0',
  `vip_active` int(4) unsigned NOT NULL DEFAULT '0',
  `salt` varchar(128) NOT NULL DEFAULT '',
  `mac_addr` varchar(16) NOT NULL DEFAULT '000000000000',
  `lock_expire` int(4) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3808 DEFAULT CHARSET=utf8;

CREATE TABLE `login_rcd` (
  `id` int(4) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` int(4) unsigned NOT NULL DEFAULT '0',
  `login_time` int(4) unsigned NOT NULL DEFAULT '0',
  `online_second` int(4) unsigned NOT NULL DEFAULT '0',
  `mac_adr` char(12) NOT NULL DEFAULT '',
  `ip_adr` char(16) NOT NULL DEFAULT '0',
  `res_src` char(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;