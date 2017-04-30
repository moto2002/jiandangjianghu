
Å/
common/toproto/aoi/aoi.proto";
S2c_aoi_sync_int
rid (	
key (	
value ("A
S2c_aoi_sync_repeatint
rid (	
key (	
value (">
S2c_aoi_sync_string
rid (	
key (	
value (	"’
S2c_aoi_syncplayer
rid (	
name (	
grade (
shape (
speed (
dir360 (
weapon (
setno (
fashion	 (
teamids
 (	
comp (
buff (
adname (	
extend (	
magic (	
partner (	
pkinfo (	
sex (
up_mount (
lingqin_model (
lingyi_model (
partnerhorse_model (
	pet_model (
shenjian_model (
shenyi_model (
mount_model (
jingmai_model (
up_horse (
score (
dazuo (
	isyunbiao (
clubname  (	
clubpost! (	"‘
S2c_aoi_syncnpc
rid (	
name (	
grade (
shape (
dir (
canattk (
comp (
buff (
extend	 (	
	shield_hp
 (
shield_hpmax (
shield_buffid ("ç
Aoi_add_normalmsg
map_no (
map_id (
rid (		
x (	
y (	
z (

hp (
hpmax (
char_no	 ("X
S2c_aoi_addplayer 
nmsg (2.Aoi_add_normalmsg!
sync (2.S2c_aoi_syncplayer"V
S2c_aoi_addself 
nmsg (2.Aoi_add_normalmsg!
sync (2.S2c_aoi_syncplayer"R
S2c_aoi_addnpc 
nmsg (2.Aoi_add_normalmsg
sync (2.S2c_aoi_syncnpc"Y
S2c_aoi_move
rid (		
x (	
y (	
z (
speed (
type ("<
S2c_aoi_leave
map_no (
map_id (
rid (	"8
S2c_aoi_move_error

ox (

oy (

oz ("\
S2c_aoi_jump
map_no (
map_id (
rid (		
x (	
y (	
z ("]
C2s_aoi_convey_door
	now_mapid (
	now_mapno (
to_mapno (
doorno ("}

S2c_aoi_hp
att_id (	

id (	

hp (
nhp (
hp_max (
type (
isdie (
htype ("Ü
C2s_aoi_skill_act
skill_id (
tar_id (	

tx (

ty (
axyz (	

sx (

sz (
	timestamp ("U
Aoi_skill_calinfo
cal_id (	
att_id (	
s_rid (
	checktime ("L
C2s_aoi_skill_calinfo
s_rid (
	checktime (
	timestamp ("“
S2c_aoi_skill_act
skill_id (
att_id (	
postype (	
x (	
y (	
z (
tar_id (	

tx (

ty	 (
cal
 (2.Aoi_skill_calinfo
	timestamp (
htype ("Ü
C2s_aoi_skill_hit
skill_id (
tar_id (	

tx (

ty (
axyz (	

sx (

sz (
	timestamp ("Ü
Aoi_skill_char
tar_id (	

hp (
nhp (
hpmax (
type (
isdie (	
x (	
y (	
z	 ("‰
S2c_aoi_skill_hit
skill_id (
att_id (	
postype (	
x (	
y (	
z (

tx (

ty (
axyz	 (	"
	tar_chars
 (2.Aoi_skill_char
	timestamp (
isbegin (
htype ("'
S2c_aoi_client_addnpc
extend (	"

S2c_aoi_sp

sp ("B
S2c_aoi_skill_ctime

id (	
skill_id (
ctime ("7
S2c_aoi_ui_hp

id (	

hp (
hp_max ("<
S2c_aoi_ui_buff

id (	
buff_id (
type ("F
Aoi_ui_skill
skill_id (

skill_type (
skill_lv ("Q
S2c_aoi_own_uiinfo

id (	
uiskill (2.Aoi_ui_skill
artimid ("?
S2c_aoi_skill_add

id (	
uiskill (2.Aoi_ui_skill"Q
S2c_aoi_passskill_change

id (	
omid (
nmid (
isset ("3
Aoi_stips_circle	
x (	
y (	
r ("z
Aoi_stips_line

ax (

ay (

tx (

ty (
atype (
len (
accu (
degree ("^
Aoi_stips_sector

ax (

ay (

tx (

ty (
atype (
len ("ä
S2c_aoi_skill_tips
tips_id (!
circle (2.Aoi_stips_circle
line (2.Aoi_stips_line!
sector (2.Aoi_stips_sector"(
S2c_aoi_skill_deltips
tips_id ("9
S2c_aoi_team_hp

id (	

hp (
hp_max ("Ö
S2c_aoi_teaminfo

id (	
name (	
grade (
pos (

hp (
hpmax (
	is_leader (
shape ("(
S2c_aoi_team_cleader
leaderid (	""
S2c_aoi_team_offline

id (	" 
S2c_aoi_team_leave

id (	"S
C2s_aoi_move
pos (	
y (
dir360 (
speed (
type ("Õ
C2s_aoi_player_fly
pos (	
y (
type (
time (
dir360 (
	vertSpeed (

horizSpeed (
horizAccSpeed (
horizEndSpeed	 (
syncpos
 (
timer ("J
C2s_aoi_player_fly_finished
pos (
syncpos (
timer ("À
S2c_aoi_player_fly
pos (	
y (

id (	
type (
dir360 (
	vertSpeed (

horizSpeed (
horizAccSpeed (
horizEndSpeed	 (
syncpos
 (
timer ("V
S2c_aoi_player_fly_finished

id (	
pos (
syncpos (
timer ("2
S2c_aoi_player_fly_error
pos (	
y ("á
C2s_aoi_plot_jump
	now_mapid (
	now_mapno (
to_mapno (
doorno (
type (
pos (
syncpos ("î
S2c_aoi_plot_jump
rid (	
	now_mapid (
	now_mapno (
to_mapno (
doorno (
type (
pos (
syncpos ("W
Aoi_bufftips
photo (
name (	
key (	
value (
svalue (	"
C2s_aoi_bufftips
rid (	"<
S2c_aoi_bufftips
rid (	
tips (2.Aoi_bufftips"6
S2c_aoi_flydodge
flydodge (
cooltime ("Ò
S2c_aoi_chat_public
channel (
	send_type (
	chat_name (	
chat_msg (	
sex (
uid (	
	chat_time (
grade (
photo	 (
voice_sn
 (	

voice_time (
club_id (
team_id ("T
C2s_aoi_sprint
pos (
fpos (	
y (
dir360 (
type ("6
S2c_aoi_sprint
rid (	
fpos (	
y ("&
S2c_aoi_changemap_type
type ("#
C2s_aoi_searchnpc
npc_no (