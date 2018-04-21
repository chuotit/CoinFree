﻿$('body').attr('ng-app', 'betApp').attr('ng-controller', 'X10Controller');
$('#double_your_btc_stake').attr('ng-model', 'btcForBet');
$('#double_your_btc_payout_multiplier').attr('ng-model', 'payout');
$('#main_content').append(`
<div class="pro-bet" ng-show="betOnline">
		<button type="button" class="close">X</button>
		<div class="setting-content">
			<div class="left-content">
				<div class="row">
					<div class="large-8 small-8 columns">
						<div class="row">
							<div class="large-5 small-5 columns">
								<fieldset>
									<legend>Cài đặt:</legend>
									<div class="row">
										<div class="large-7 small-7 columns">
											<div class="group">
												<label class="title">Cược ban đầu</label>
												<select ng-options="type.value as type.value for type in btcBases" ng-model="btcBase" ng-disabled="onBetting" ng-change="updateBetList()"></select>
											</div>
										</div>
										<div class="large-5 small-5 columns">
											<div class="group">
												<label class="title">Payout</label>
												<select ng-options="type.Value as type.Value for type in payouts" ng-model="payout" ng-disabled="onBetting" ng-change="updateBetList()"></select>
											</div>
										</div>
									</div>
								</fieldset>
							</div>
							<div class="large-7 small-7 columns">
								<fieldset>
									<legend>Tùy chọn:</legend>
									<div class="group">
										<label class="title">Kiểu BET</label>
										<ul class="modes-list ul-list">
											<li ng-repeat="item in betModes">
												<label>
													<input type="radio" name="betModeOption" ng-model="$parent.betMode" ng-value="item.value">{{item.name}}</label>
											</li>
										</ul>
									</div>
								</fieldset>
							</div>
						</div>
						<div class="row">
							<div class="large-8 small-8 columns">
								<fieldset>
									<legend>Tùy chọn rà chuỗi và cược:</legend>
									<div class="row">
										<div class="large-4 small-4 columns">
											<div class="group">
												<label class="title">Chuỗi rà</label>
												<select style="max-width: 50px; display: inline;" ng-options="type.value as type.value for type in betProbes" ng-model="betProbe"
												 ng-disabled="onBetting" ng-change="updateBetList();"></select>
											</div>
										</div>
										<div class="large-4 small-4 columns">
											<div class="group">
												<label class="title">Điểm cược</label>
												<select style="max-width: 50px; display: inline;" ng-options="type.value as type.value for type in betPlacings" ng-model="betPlacing"
												 ng-disabled="onBetting" ng-change="updateBetList();"></select>
											</div>
										</div>
										<div class="large-4 small-4 columns">
											<div class="group">
												<label class="title">Cược sau rà</label>
												<select style="max-width: 97px; display: inline;" ng-options="type.value as type.value for type in btcPlusList" ng-model="btcPlus" ng-disabled="onBetting" ng-change="updateBetList(false)"></select>
											</div>
										</div>
										<div class="large-3 small-3 columns">
											<div class="group">
												<label class="title">Tăng %</label>
												<select style="max-width: 50px; display: inline;" ng-options="type.value as type.value for type in percentIncreases" ng-model="percentIncrease"
												 ng-disabled="onBetting" ng-change="updateBetList(false)"></select>
												<span>%</span>
											</div>
										</div>
										<div class="large-4 small-4 columns">
											<div class="group">
												<label class="title">Tăng % khi</label>
												<span>thua</span>
												<select style="max-width: 40px; display: inline;" ng-options="type.value as type.value for type in increaseWhenLosts" ng-model="increaseWhenLost"
													ng-disabled="onBetting" ng-change="updateBetList()"></select>
												<span>lần</span>
											</div>
										</div>
										<div class="large-5 small-5 columns">
											<div class="group">
												<label class="title">Cược lại sau khi</label>
												<span>thua</span>
												<select style="max-width: 39px; display: inline;" ng-options="type.index as type.index for type in betList" ng-model="betLoseAllowed"
												 ng-disabled="onBetting" ng-change="updateBetList()"></select>
												 <span> lần cược</span>
											</div>
										</div>
									</div>
								</fieldset>
							</div>
							<div class="large-4 small-4 columns">
								<fieldset style="min-height: 104px;">
									<legend>Tạm dừng</legend>
									<div class="group">
										<label class="title">Sau khi ăn</label>
										<input type="checkbox" name="pauseOnWin" ng-model="pauseOnWin" />
										<span>Dừng</span>
									</div>
									<div class="group">
										<label class="title">Sau khi bet</label>
										<select style="display: inline-block; width: 65px;" ng-options="type.value as type.value for type in betTargetList" ng-model="betTarget"></select>
										<span>lần</span>
									</div>
								</fieldset>
							</div>
						</div>
						<div class="row">
							<div class="large-12 small-12 columns">
								<fieldset style="min-height: 50px;">
									<legend>Tốc độ BET</legend>
									<ul class="speed-list ul-list">
										<li ng-repeat="item in betSpeeds">
											<label>
												<input type="radio" name="betSpeedOption" ng-model="$parent.betSpeed" ng-value="item.value" ng-disabled="betSpeedAuto" />{{item.name}}</label>
										</li>
										<li>
											<label>
												<input type="checkbox" ng-model="betSpeedAuto" />Auto</label>
										</li>
									</ul>
									<div class="clear"></div>
								</fieldset>
							</div>
						</div>
						<div class="tools-info">
							<div class="marquee-area" ng-if="toolActive === true">
								<marquee onMouseOver="this.stop()" onMouseOut="this.start()">Bản
									<span class="tool-name">ProBET</span> này được phát triển bởi nhóm
									<a target="_blank" href="https://www.facebook.com/groups/142471483081439/" class="author">Coin Free</a>
									</span> - Mọi thắc mắc hoặc cần hỗ trợ, các bạn vui lòng liên hệ theo HOTLINE ở dưới - Chúc các bạn chơi vui vẻ!</marquee>
							</div>
							<div class="active-account" ng-if="toolActive === false">
								<label class="red-color center">Tool chưa được kích hoạt, vui lòng liên hệ hotline để được hỗ trợ</label>
							</div>
							<label class="hot-line">HOTLINE: 0989.468.567 - 0961.179.678</label>
							<label class="version">Phiên bản: 1.2.1</label>
						</div>
					</div>
					<div class="large-4 small-4 columns">
						<fieldset>
							<legend>Payout cơ bản:</legend>
							<div class="group">
								<div class="button-list row">
									<div class="button-item large-3 columns"><button ng-click="changPayout(1.5)" ng-class="{'active': payout === 1.5}" ng-disabled="payout === 1.5 || onBetting">1.5</button></div>
									<div class="button-item large-3 columns"><button ng-click="changPayout(2)" ng-class="{'active': payout === 2}" ng-disabled="payout === 2 || onBetting">2</button></div>
									<div class="button-item large-3 columns"><button ng-click="changPayout(2.5)" ng-class="{'active': payout === 2.5}" ng-disabled="payout === 2.5 || onBetting">2.5</button></div>
									<div class="button-item large-3 columns"><button ng-click="changPayout(10)" ng-class="{'active': payout === 10}" ng-disabled="payout === 10 || onBetting">10</button></div>
								</div>
							</div>
						</fieldset>
						<fieldset>
							<legend>Thống kê:</legend>
							<div class="row">
								<div class="large-6 small-6 columns">
									<div class="group">
										<label class="title">Trước:</label>
										<div class="btc-display red-color">{{btcBefore}}</div>
									</div>
								</div>
								<div class="large-6 small-6 columns">
									<div class="group">
										<label class="title">Sau:</label>
										<div id="btcAfter" class="btc-display green-color">{{btcAfter}}</div>
									</div>
								</div>
								<div class="large-6 small-6 columns">
									<div class="group">
										<label class="title">Lợi nhuận:</label>
										<div class="btc-display {{btcIncrement >= 0?'green-color':'red-color'}}">{{btcIncrement}}</div>
									</div>
								</div>
								<div class="large-6 small-6 columns">
									<div class="group">
										<label class="title">Số lần Bet:</label>
										<div class="btc-display red-color">{{betCount}}</div>
									</div>
								</div>
							</div>
						</fieldset>
						<fieldset style="min-height: 110px;">
							<legend>Phân tích</legend>
							<div class="group">
								<label class="title">Chuỗi an toàn:
									<span class="red-color">{{betAllowed.index}}</span> 
									(<span class="green-color">{{betAllowed.btcBet}}</span>)
								</label>
							</div>
							<div class="group">
								<label class="title">Cược lớn nhất:
									<span class="red-color">{{betMaxLoseAllowed}}</span>
									 (<span class="red-color">{{btcMaxLoseAllowed}}</span>)
								</label>
							</div>
							<div class="group">
								<label class="title">Cược lại sau khi thua: {{betLoseAllowed}} lần cược</label>
								<span>
									<span class="red-color">{{btcLoseAllowed}}</span>
									(<span class="green-color"> còn lại {{btcRemain}}</span>)
								</span>
							</div>
						</fieldset>
					</div>
				</div>
			</div>
			<div class="right-content">
				<ul class="timeline-list">
					<li ng-if="betList" ng-repeat="item in betList" id="line{{item.index}}" ng-class="{'active': item.index == betItemIndex}">
						<div class="bet-number">{{item.index}}</div>
						<div class="btc-bet">{{item.btcBet}}</div>
						<div class="btc-win" ng-class="{'positive': item.btcWin >= 0}">{{item.btcWin}}</div>
					</li>
					<li class="unknown-list" ng-if="betList.length == 0">
						<span>Không xác định được chuỗi Bet</span>
					</li>
				</ul>
			</div>
			<div class="controls">
				<div class="row">
					<div class="large-6 small-6 columns">
						<button ng-disabled="onBetting || toolActive === false" ng-click="startBet()" class="bet-start">Bắt đầu</button>
					</div>
					<div class="large-6 small-6 columns">
						<button ng-disabled="!onBetting" ng-click="pauseBet()" class="bet-pause">Tạm dừng</button>
					</div>
				</div>
			</div>
		</div>
		<div class="chart-general" ng-if="generalList.length > 0">
			<ul class="general-list" style="height: {{betMaxLose * (payout === 10 ? 1 : 5) + 10}}px;">
				<li class="general-item lose-item" style="height: {{betMaxLose * (payout === 10 ? 1 : 5)}}px;">
					<span>{{betMaxLose}}</span>
				</li>
				<li ng-repeat="item in generalList" class="general-item {{item.style}}" style="height: {{item.value * (payout === 10 ? 1 : 5)}}px;">
					<span>{{item.value}}</span>
				</li>
			</ul>
		</div>
	</div>
`);