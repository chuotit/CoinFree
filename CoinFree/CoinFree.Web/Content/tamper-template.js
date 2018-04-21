// ==UserScript==
// @name         ProBET
// @namespace    Hotline: 0989.468.567 - 0961.179.678
// @version      1.2.1
// @description  ProBET tools developed by https://www.facebook.com/groups/142471483081439/
// @require      http://localhost:54551/Scripts/angular.min.js?ts=5
// @require      http://localhost:54551/Scripts/js.js?ts=5
// @resource     viewHtml http://localhost:54551/Content/view.html?ts=5
// @resource     customCSS http://localhost:54551/Content/style.min.css?ts=5
// @author       Coin Free
// @match        https://freebitco.in/*
// @grant        GM_getResourceText
// @grant        GM_addStyle
// @run-at       document-idle
// ==/UserScript==

$('body').attr('ng-app', 'betApp').attr('ng-controller', 'X10Controller');
$('#double_your_btc_stake').attr('ng-model', 'btcForBet');
$('#double_your_btc_payout_multiplier').attr('ng-model', 'payout');

$('#main_content').append(GM_getResourceText("viewHtml"));
GM_addStyle(GM_getResourceText("customCSS"));
