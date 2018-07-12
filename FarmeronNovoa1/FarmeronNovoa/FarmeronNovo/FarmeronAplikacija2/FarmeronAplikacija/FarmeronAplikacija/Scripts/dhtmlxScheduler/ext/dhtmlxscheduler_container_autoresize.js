/*
@license
dhtmlxScheduler.Net v.3.3.3 

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e.config.container_autoresize=!0,e.config.month_day_min_height=90;var t=e._pre_render_events,i=!0;e._pre_render_events=function(s,a){if(!e.config.container_autoresize||!i)return t.apply(this,arguments);var n=this.xy.bar_height,r=this._colsS.heights,d=this._colsS.heights=[0,0,0,0,0,0,0],o=this._els.dhx_cal_data[0];if(s=this._table_view?this._pre_render_events_table(s,a):this._pre_render_events_line(s,a),this._table_view)if(a)this._colsS.heights=r;else{var l=o.firstChild;

if(l.rows){for(var _=0;_<l.rows.length;_++){if(d[_]++,d[_]*n>this._colsS.height-this.xy.month_head_height){var h=l.rows[_].cells,c=this._colsS.height-this.xy.month_head_height;1*this.config.max_month_events!==this.config.max_month_events||d[_]<=this.config.max_month_events?c=d[_]*n:(this.config.max_month_events+1)*n>this._colsS.height-this.xy.month_head_height&&(c=(this.config.max_month_events+1)*n);for(var u=0;u<h.length;u++)h[u].childNodes[1].style.height=c+"px";d[_]=(d[_-1]||0)+h[0].offsetHeight;

}d[_]=(d[_-1]||0)+l.rows[_].cells[0].offsetHeight}d.unshift(0),l.parentNode.offsetHeight<l.parentNode.scrollHeight&&!l._h_fix}else if(s.length||"visible"!=this._els.dhx_multi_day[0].style.visibility||(d[0]=-1),s.length||-1==d[0]){var g=(l.parentNode.childNodes,(d[0]+1)*n+1+"px");o.style.top=this._els.dhx_cal_navline[0].offsetHeight+this._els.dhx_cal_header[0].offsetHeight+parseInt(g,10)+"px",o.style.height=this._obj.offsetHeight-parseInt(o.style.top,10)-(this.xy.margin_top||0)+"px";var v=this._els.dhx_multi_day[0];

v.style.height=g,v.style.visibility=-1==d[0]?"hidden":"visible",v=this._els.dhx_multi_day[1],v.style.height=g,v.style.visibility=-1==d[0]?"hidden":"visible",v.className=d[0]?"dhx_multi_day_icon":"dhx_multi_day_icon_small",this._dy_shift=(d[0]+1)*n,d[0]=0}}return s};var s=["dhx_cal_navline","dhx_cal_header","dhx_multi_day","dhx_cal_data"],a=function(t){for(var i=0,a=0;a<s.length;a++){var n=s[a],r=e._els[n]?e._els[n][0]:null,d=0;switch(n){case"dhx_cal_navline":case"dhx_cal_header":d=parseInt(r.style.height,10);

break;case"dhx_multi_day":d=r?r.offsetHeight:0,1==d&&(d=0);break;case"dhx_cal_data":var o=e.getState().mode;if(d=r.childNodes[1]&&"month"!=o?r.childNodes[1].offsetHeight:Math.max(r.offsetHeight-1,r.scrollHeight),"month"==o){if(e.config.month_day_min_height&&!t){var l=r.getElementsByTagName("tr").length;d=l*e.config.month_day_min_height}t&&(r.style.height=d+"px")}if(e.matrix&&e.matrix[o])if(t)d+=2,r.style.height=d+"px";else{d=2;for(var _=e.matrix[o],h=_.y_unit,c=0;c<h.length;c++)d+=h[c].children?_.folder_dy||_.dy:_.dy;

}("day"==o||"week"==o)&&(d+=2)}i+=d}e._obj.style.height=i+"px",t||e.updateView()},n=function(){if(!e.config.container_autoresize||!i)return!0;var t=e.getState().mode;a(),(e.matrix&&e.matrix[t]||"month"==t)&&window.setTimeout(function(){a(!0)},1)};e.attachEvent("onViewChange",n),e.attachEvent("onXLE",n),e.attachEvent("onEventChanged",n),e.attachEvent("onEventCreated",n),e.attachEvent("onEventAdded",n),e.attachEvent("onEventDeleted",n),e.attachEvent("onAfterSchedulerResize",n),e.attachEvent("onClearAll",n),
e.attachEvent("onBeforeExpand",function(){return i=!1,!0}),e.attachEvent("onBeforeCollapse",function(){return i=!0,!0})}()});