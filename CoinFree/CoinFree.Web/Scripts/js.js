(function () {
    var app = angular.module("betApp", []);

    app.controller("X10Controller", ['$scope', '$timeout', '$http', function ($scope, $timeout, $http) {
        {
            var betButton = 'hi';
            $scope.betOnline = true;
            getBetBases('0.00000001');
            $scope.betSpeedAuto = true;
            $scope.btcForBet = $scope.btcBase;
            $scope.balance = $('#balance').text();
            var balance = $('#balance').text();
            $scope.btcBefore = $scope.balance;
            $scope.btcAfter = $scope.btcBefore;
            $scope.btcIncrement = subBTC($scope.btcAfter, $scope.btcBefore);
            $scope.betMaxLose = $scope.betMaxLoseAllowed = $scope.betCount = 0;
            $scope.btcMaxLoseAllowed = '0.00000001';
            $scope.betHiFlg = true;
            $scope.betType = 8;
            $scope.betOnline = true;
            $scope.steps = 1;
            $scope.enableDeletePayoutMode = false;
            var coinAddress = window.aZa;
            var baseUrl = 'http://localhost:54551';

            $http({
                method: 'GET',
                url: baseUrl + '/user/CheckUserByCoinAddress?address=' + coinAddress
            }).then(
                function successCallback(response) {
                    $scope.toolActive = response.data;
                }, function errorCallback(error) {
                    $scope.toolActive = false;
                }
            );
            $scope.toolActive = true;


            getBetModes(1);
            getPayouts('2.5');
            getBetProbes();
            getBtcPlusList();
            getbetTargetList(20000);
            getPercentIncreases(100);
            getBetSpeeds(166);
            getBetAfterProbes(100);
            getIncreaseWhenLosts();
            getBetPlacings(2);

            $scope.updateBetList = function (updateAllowed) {
                $scope.betList = updateBetList(0);
                $scope.betAllowed = $scope.betList.slice(-1)[0];
                if (updateAllowed === false) {
                    $scope.betLoseAllowed = $scope.betList.length - 1;
                }
                $scope.btcLoseAllowed = $scope.betList[$scope.betLoseAllowed - 1].btcLose;
                $scope.btcRemain = $scope.betList[$scope.betLoseAllowed - 1].btcRemain;
            };

            var loseCount = winCount = probeCount = $scope.onBigBetCount = 0,
                btcLose = 0,
                betTypeCount = 0,
                btcRandom, onBigBetOfLose;
            var generalList = [];
            $scope.betItemIndex = 1;
            $scope.bigBetFlg = false;
            $('#balance').bind('DOMSubtreeModified', function (e) {
                if ($(e.currentTarget).is(':contains(".")')) {
                    $timeout(function () {
                        $scope.balance = $('#balance').text();
                        betButton = getBetButton($scope.betMode);
                        btcRandom = betButton === 'hi' ? '0.00000001' : '0.00000002';
                        var btcOld = $scope.btcAfter;
                        $scope.btcAfter = $scope.balance;
                        $scope.btcIncrement = subBTC($scope.btcAfter, $scope.btcBefore);
                        if ($scope.onBetting === true) {
                            $scope.betCount++;
                            if ($scope.btcAfter >= btcOld) {
                                btcLose = 0;
                                winCount++;

                                if ($scope.betCount >= $scope.betTarget || $scope.pauseOnWin === true) {
                                    $scope.onBetting = false;
                                }
                                generalList = getGeneralist(loseCount, generalList, 'lose-item');

                                if ($scope.betType === 8) {
                                    $scope.btcForBet = $scope.btcBase;

                                    if (loseCount !== 0 && loseCount <= $scope.betPlacing) {
                                        $scope.onBigBetCount = 0;
                                        $scope.betItemIndex = $scope.onBigBetCount + 1;
                                        $scope.bigBetFlg = false;
                                    } else {
                                        $scope.betItemIndex = $scope.onBigBetCount === 0 ? $scope.onBigBetCount + 1 : $scope.onBigBetCount;
                                    }

                                    if ($scope.betItemIndex >= 2) {
                                        document.getElementById('line' + ($scope.betItemIndex - 1)).scrollIntoView(true);
                                    } else {
                                        document.getElementById('line' + ($scope.betItemIndex)).scrollIntoView(true);
                                    }

                                    $scope.betMaxLoseAllowed = $scope.betMaxLoseAllowed > $scope.onBigBetCount + 1 ? $scope.betMaxLoseAllowed : $scope.onBigBetCount + 1;
                                    $scope.btcMaxLoseAllowed = $scope.betList[$scope.onBigBetCount].btcBet > $scope.btcMaxLoseAllowed ? $scope.betList[$scope.onBigBetCount].btcBet : $scope.btcMaxLoseAllowed;
                                    $scope.betMaxLose = $scope.betMaxLose > loseCount ? $scope.betMaxLose : loseCount;
                                }
                                loseCount = 0;
                            } else {
                                loseCount++;

                                generalList = getGeneralist(winCount, generalList, 'win-item');

                                if ($scope.betType === 8) {
                                    if ($scope.bigBetFlg === false && loseCount === 1) {
                                        if ($scope.userSetting.BetProbe !== 0) {
                                            var check = 0;
                                            for (var i = 1; i <= $scope.userSetting.BetProbe; i++) {
                                                if ((generalList[(generalList.length - i * 2)] ? generalList[(generalList.length - i * 2)].value : 0) >= $scope.betPlacing) {
                                                    check++;
                                                }
                                            }

                                            if (check === $scope.userSetting.BetProbe) {
                                                $scope.bigBetFlg = true;
                                            }
                                        } else {
                                            $scope.bigBetFlg = true;
                                        }
                                    }

                                    if (loseCount <= $scope.betPlacing && $scope.bigBetFlg === true) {
                                        $scope.onBigBetCount++
                                        $scope.btcForBet = $scope.onBigBetCount >= $scope.betLoseAllowed ? $scope.betList[0].btcBet : $scope.betList[$scope.onBigBetCount - 1].btcBet;
                                        $scope.betItemIndex = $scope.onBigBetCount >= $scope.betLoseAllowed ? 0 : $scope.onBigBetCount;
                                        if ($scope.betItemIndex >= 3) {
                                            document.getElementById('line' + ($scope.betItemIndex - 1)).scrollIntoView(true);
                                        }
                                    } else {
                                        $scope.btcForBet = $scope.btcBase;
                                    }
                                }
                                btcLose = sumBTC(btcLose, $scope.btcForBet);
                                winCount = 0;
                            }
                            // $scope.betSpeed = getBetSpeedAutoPlay(loseCount);
                            // console.log(loseCount !== 0 ? 'loseCount:' + loseCount : "winCount:" + winCount, '$scope.bigBetFlg' + $scope.bigBetFlg, "$scope.btcForBet:" + $scope.btcForBet, "$scope.onBigBetCount:" + $scope.onBigBetCount);
                            // $timeout(function() {
                            $scope.disabledButton = false;
                            $timeout(function () {
                                if ($scope.toolActive === true) {
                                    $('#double_your_btc_bet_' + betButton + '_button').trigger('click');
                                }
                            }, $scope.betSpeed);
                            // }, 450);

                            $scope.generalList = generalList;
                        }
                    });
                }
            });

            $scope.startBet = function () {
                $scope.onBetting = true;
                $scope.disabledButton = false;
                $timeout(function () {
                    if ($scope.toolActive === true) {
                        $('#double_your_btc_bet_' + betButton + '_button').trigger('click');
                    }
                }, $scope.betSpeed);
            };

            $scope.pauseBet = function () {
                $scope.onBetting = false;
                $scope.disabledButton = false;
            };

            $scope.deletePayoutMode = function () {
                $scope.enableDeletePayoutMode = true;
                console.log($scope.enableDeletePayoutMode);
            };

            $scope.deletePayout = function (id) {
                $http({
                    method: 'POST',
                    url: baseUrl + '/UserSetting/DeleteUserSetting/?id=' + id
                }).then(
                    function successCallback(response) {
                        console.log(response)
                    }, function errorCallback(error) {
                        console.log(error);
                    }
                    );
            };

            $scope.changePayout = changePayout;
            function changePayout(payout) {
                $scope.payout = payout;
                $http({
                    method: 'GET',
                    url: baseUrl + '/UserSetting/GetSetting/?gameType=base&payout=' + payout + '&coinAddress=' + coinAddress
                }).then(
                        function successCallback(response) {
                            $scope.userSetting = response.data.userSetting[0];
                            $scope.betList = updateBetList(0);
                            $scope.betAllowed = $scope.betList.slice(-1)[0];
                            $scope.betLoseAllowed = $scope.betList.slice(-2)[0].index;
                            $scope.btcLoseAllowed = $scope.betList[$scope.betLoseAllowed - 1].btcLose;
                            $scope.btcRemain = $scope.betList[$scope.betLoseAllowed - 1].btcRemain;
                            console.log($scope.userSetting);
                        //$scope.userSetting = {
                        //    betProbe = 2,
                        //    btcPlus = '0.00000100',
                        //    increaseWhenLost = 1,
                        //    percentIncrease = 250,
                        //    betPlacing = 2
                        //}

                        //$scope.userSetting.BetProbe = 2;
                        //$scope.userSetting.BtcPlus = '0.00000100';
                        //$scope.userSetting.IncreaseWhenLost = 1;
                        //$scope.userSetting.PercentIncrease = 250;
                        //$scope.betPlacing = 2;

                        }, function errorCallback(error) {
                            console.log(error);
                    }
                );
            };

            function getBetModes(betModeDefault) {
                $scope.betMode = betModeDefault;
                $scope.betModes = [{
                    name: 'Random',
                    value: 1
                }, {
                    name: 'Alternate',
                    value: 2
                }, {
                    name: 'HI',
                    value: 3
                }, {
                    name: 'LO',
                    value: 4
                }];
            }

            function getBetBases(btcBaseDefault) {
                $scope.btcBase = btcBaseDefault;
                var btcBases = [];
                for (i = 1; i <= 20; i++) {
                    btcBases.push({
                        value: numberToSts(i)
                    });
                }
                $scope.btcBases = btcBases;
            }

            function getPayouts(payoutDefault) {
                $http({
                    method: 'GET',
                    url: baseUrl + '/UserSetting/GetPayout/?gameType=base&coinAddress=' + coinAddress
                }).then(
                    function successCallback(response) {
                        $scope.payouts = response.data.payoutList;
                    }, function errorCallback(error) {
                        console.log(error);
                    }
                );
                changePayout(payoutDefault);
            }

            function getBetPlacings(betPlacingDefault) {
                $scope.betPlacing = betPlacingDefault;
                var betPlacings = [];
                for (i = 0; i <= 100; i++) {
                    betPlacings.push({
                        value: i
                    });
                }
                $scope.betPlacings = betPlacings;
            }

            function getBetProbes() {
                var betProbes = [];
                for (i = 0; i <= 100; i++) {
                    betProbes.push({
                        value: i
                    });
                }
                $scope.betProbes = betProbes;
            }

            function getIncreaseWhenLosts() {
                var increaseWhenLosts = [];
                for (i = 0; i <= 100; i++) {
                    increaseWhenLosts.push({
                        value: i
                    });
                }
                $scope.increaseWhenLosts = increaseWhenLosts;
            }

            function getBtcPlusList() {
                var btcPlusList = [];
                for (i = 1; i <= 50000; i++) {
                    if (i <= 15) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    } else if (i <= 50 && i % 5 === 0) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    } else if (i <= 200 && i % 25 === 0) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    } else if (i <= 1000 && i % 100 === 0) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    } else if (i <= 5000 && i % 500 === 0) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    } else if (i <= 50000 && i % 10000 === 0) {
                        btcPlusList.push({
                            value: numberToSts(i)
                        });
                    }
                }
                $scope.btcPlusList = btcPlusList;
            }

            function getbetTargetList(betTargetDefault) {
                $scope.betTarget = betTargetDefault;
                var betTargetList = [];
                for (i = 100; i <= 50000; i++) {
                    if (i <= 100 && i % 5 === 0) {
                        betTargetList.push({
                            value: i
                        });
                    } else if (i <= 200 && i % 25 === 0) {
                        betTargetList.push({
                            value: i
                        });
                    } else if (i <= 1000 && i % 100 === 0) {
                        betTargetList.push({
                            value: i
                        });
                    } else if (i <= 5000 && i % 500 === 0) {
                        betTargetList.push({
                            value: i
                        });
                    } else if (i <= 50000 && i % 10000 === 0) {
                        betTargetList.push({
                            value: i
                        });
                    }
                }
                $scope.betTargetList = betTargetList;
            }

            function getPercentIncreases() {
                var percentIncreases = [];
                for (i = 1; i <= 300; i++) {
                    percentIncreases.push({
                        value: i
                    });
                }
                $scope.percentIncreases = percentIncreases;
            }

            function getBetSpeeds(betSpeed) {
                $scope.betSpeed = betSpeed;
                $scope.betSpeeds = [{
                    name: 'Cực nhanh',
                    value: 166
                }, {
                    name: 'nhanh',
                    value: 568
                }, {
                    name: 'Bình thường',
                    value: 999
                }, {
                    name: 'chậm',
                    value: 1568
                }, {
                    name: 'Cực chậm',
                    value: 2226
                }];
            }

            function getBetAfterProbes(betAfterProbe) {
                $scope.betAfterProbe = betAfterProbe;
                var betAfterProbes = [];
                for (i = 3; i <= 100; i++) {
                    betAfterProbes.push({
                        value: i
                    });
                }
                $scope.betAfterProbes = betAfterProbes;
            }

            function getGeneralist(count, generalList, style) {
                if (count > 0) {
                    generalList.push({
                        value: count,
                        style: style
                    });
                }
                if (generalList.length > 65) {
                    generalList = generalList.slice(1, generalList.length);
                }
                return generalList;
            }

            function updateBetList(position) {
                var btcBet = $scope.payout <= 2.5 ? $scope.userSetting.BtcPlus : $scope.userSetting.BtcPlus;
                var index = 0,
                    btcWin = 0,
                    btcLose = 0,
                    btcRemain = $scope.btcAfter;
                var betList = [];

                do {
                    index++;
                    btcWin = multiBTC(btcBet, $scope.payout - 1);
                    btcInterest = subBTC(multiBTC(btcBet, $scope.payout - 1), btcLose);
                    btcLose = sumBTC(btcLose, btcBet);
                    btcRemain = subBTC(btcRemain, btcBet);

                    var betItem = {
                        index: index,
                        btcBet: btcBet,
                        btcWin: btcWin,
                        btcLose: btcLose,
                        btcInterest: btcInterest,
                        btcRemain: btcRemain
                    };
                    if (btcBet < 0.00000001) {
                        betList = [];
                        return;
                    } else {
                        betList.push(betItem);
                    }
                    btcBet = getBtcBet(index, btcBet, btcLose);

                } while (btcBet < btcRemain);
                if (position === 0) {
                    return betList;
                } else {
                    return betList[position];
                }
            }

            function getBtcBet(index, btcPrevBet, btcLose) {
                if ($scope.payout <= 2.5) {
                    return (btcPrevBet * getPercent($scope.userSetting.PercentIncrease)).toFixed(8);
                } else if ($scope.payout === 10) {
                    var btcBet = btcPrevBet;
                    // if (index > $scope.userSetting.IncreaseWhenLost && (index % $scope.userSetting.IncreaseWhenLost === $scope.userSetting.BetProbe % $scope.userSetting.IncreaseWhenLost)) {
                    if (index % $scope.userSetting.IncreaseWhenLost === 0) {
                        btcBet = (btcPrevBet * getPercent($scope.userSetting.PercentIncrease)).toFixed(8);
                    }
                    // if ($scope.betAfterProbe && index >= $scope.betAfterProbe) {
                    //     btcBet = (btcLose / ($scope.payout - 1)).toFixed(8);
                    // }
                    return btcBet;
                }
            }

            function sumBTC(btcOne, btcTwo) {
                return (btcOne * 1 + btcTwo * 1).toFixed(8);
            }

            function subBTC(btcOne, btcTwo) {
                return (btcOne * 1 - btcTwo * 1).toFixed(8);
            }

            function multiBTC(btcOne, btcTwo) {
                return ((btcOne * 1) * (btcTwo * 1)).toFixed(8);
            }

            function getPercent(percent) {
                return 1 + (percent / 100);
            }

            function getRandomInt(min, max) {
                return Math.floor(Math.random() * (max - min + 1)) + min;
            }

            function getBetButton(betMode) {
                var betButton = 'hi';
                switch (betMode) {
                    case 1:
                        var random_boolean = Math.random() >= 0.5;
                        $scope.betHiFlg = random_boolean;
                        break;
                    case 2:
                        $scope.betHiFlg = !$scope.betHiFlg;
                        break;
                    case 3:
                        $scope.betHiFlg = true;
                        break;
                    case 4:
                        $scope.betHiFlg = false;
                        break;
                }
                if ($scope.betHiFlg) {
                    betButton = 'hi';
                } else {
                    betButton = 'lo';
                }
                return betButton;
            }

            function numberToSts(num) {
                return (num / 100000000).toFixed(8);
            }

            function getBetSpeedAutoPlay(loseIndex) {
                var betSpeed = $scope.betSpeeds[0].value;
                if ($scope.betSpeedAuto) {
                    var maxBetIndex = $scope.betList.length;
                    if (loseIndex <= $scope.userSetting.BetProbe) {
                        betSpeed = $scope.betSpeeds[0].value;
                    } else if (loseIndex <= (maxBetIndex - $scope.userSetting.BetProbe) / 3 + $scope.userSetting.BetProbe) {
                        betSpeed = $scope.betSpeeds[1].value;
                    } else if (loseIndex <= (maxBetIndex - $scope.userSetting.BetProbe) / 2 + $scope.userSetting.BetProbe) {
                        betSpeed = $scope.betSpeeds[2].value;
                    } else if (loseIndex <= (maxBetIndex - $scope.userSetting.BetProbe) / 1.5 + $scope.betProbe) {
                        betSpeed = $scope.betSpeeds[3].value;
                    } else {
                        betSpeed = $scope.betSpeeds[4].value;
                    }
                }
                return betSpeed;
            }

            var loseIndex = 0;
            $scope.requestBet = function () {
                $scope.disabledButton = true;
                if ($scope.onBetting === true) {
                    var payoutVal = 2;
                    switch ($scope.payout) {
                        case 1.5:
                            payoutVal = 0.40;
                            break;
                        case 2:
                            payoutVal = 0.53;
                            break;
                        case 2.5:
                            payoutVal = 0.65;
                            break;
                        case 3:
                            payoutVal = 0.8;
                            break;
                        case 10:
                            payoutVal = 0.9;
                            break;
                    }
                    $scope.winFlg = Math.random() >= payoutVal;
                    if ($scope.winFlg) {
                        loseIndex = 0;
                        $('#double_your_btc_bet_win_').text('You BET ' + betButton.toUpperCase() + ' so you win ' + ($scope.btcForBet * ($scope.payout - 1)).toFixed(8) + ' BTC');
                        $('#balance').text(sumBTC($scope.balance, $scope.btcForBet * ($scope.payout - 1)));
                    } else {
                        loseIndex++;
                        $('#double_your_btc_bet_lose_').text('You BET ' + betButton.toUpperCase() + ' so you lose ' + $scope.btcForBet + ' BTC');
                        $('#balance').text(subBTC($scope.balance, $scope.btcForBet));
                    }
                    $scope.balance = $('#balance').text();
                }
            };
        }
    }]);
})();