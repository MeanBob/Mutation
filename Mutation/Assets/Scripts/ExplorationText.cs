using UnityEngine;
using System.Collections;

public class ExplorationText  : ScriptableObject
{

	public string[,] dialogue =  new string[10, 11];

	public void Start()
	{
		//A row
		dialogue[0,0] = "A grove of trees encircles a small pond of clear water.  A trail of golden dust disappears from your sight. Magic dragonflies flutter to and fro and the sudden urge to drop a poopy fills your aching gut.";
		dialogue[1,0] = "Trees open to blue sky here. The turbulent ground drops off, exposing the face of a steep canyon you don’t get too close to.";
		dialogue[2,0] = "You stand in the middle of an empty, green valley. ";
		dialogue[3,0] = "The surrounding grass bores you. Did it recently rain?  ";
		dialogue[4,0] = "The expansive valley is cut sharply into the jagged mountains from repeated snowmelt. Suddenly you’re glad you paid attention in geography class.";
		dialogue[5,0] = "Green fields spotted with wild, white flowers make up the whole of your view as this valley gives way to an endless expanse of majestic nature.";
		dialogue[6,0] = "You peer up at the ridgeline and think you see a pack of mountain goats. How did they get all the way up there, you wonder. I guess that’s why they call them mountain goats.";
		dialogue[7,0] = "You found a path leading to a jungle.";
		dialogue[8,0] = "The terrane is jungle here. You notice a fleet of army ants marching to their own tune. You stop to watch them as they maintain uniform march in strict regiment. If only the rest of the world were as organized and disciplined. ";
		dialogue[9,0] = "The corner of the map! You OCD maniac, go outside. ";
		//B row
		dialogue[0,1] = "The jungle is replete with foliage as thick tree trunks host moss and vines. You make your argous way forward."; 
		dialogue[1,1] = "You press through a thicket and find a natural opening in the forest! In the center of a sunlit patch of grass you see a wishing well. The light at the bottom of this well shimmers in a little disc which reminds you of the moon. Too bad you don’t have any change to throw in there."; 
		dialogue[2,1] = "The jungle gives way to a clearing and a vista of grass offers a view of the valley below. What’s this strange feeling you are having?"; 
		dialogue[3,1] = "The grassy plain is refreshing as a warm breeze carries leafs across your path."; 
		dialogue[4,1] = "A trail intersects your progress. To the West is appears to run along the edge of a valley. To the East you see the wide river valley."; 
		dialogue[5,1] = "A lost peasant stumbles around a corner. He is sweaty and bewildered and speaks in long drawls. “I saw some bandits… bandits…. bandits to the East, yesterday… yes I did.”"; 
		dialogue[6,1] = "The path devised the dense jungle on one side and the opening vally on the other."; 
		dialogue[7,1] = "The trail cuts sharply West here, leaving you surrounded by jungle on all sides. You hear the caw of a toucan but do not see him."; 
		dialogue[8,1] = "For some reason you step deeper into the jungle You fight your way through thick forest to do so."; 
		dialogue[9,1] = "The thickest the jungle gets is where you are. Lucky you."; 
		//C row
		dialogue[0,2] = "Here a wall of thick vines prevents your progress forward. To the East the wide channel of the river daines into a ravine and a waterfall. To the West more jungle awaits.";
		dialogue[1,2] = "The jungle grows only more dense and you begin to wonder how much further you can get before the landscape becomes impassable.";
		dialogue[2,2] = "You weed your way through dense jungle. This is a very ambitious path to choose, young adventurer.";
		dialogue[3,2] = "Stepping off the path you enter the thicket of vines and dense shrubbery that composes a Jungle. ";
		dialogue[4,2] = "Just a dirt path.  Nothing special.";
		dialogue[5,2] = "Stepping off the path you enter a dense world of dank aromas where filtered light makes its way down from the canopy above.";
		dialogue[6,2] = "Massive trees - whose roots protrude the soft Earth - climb to heights above the likes of which only birds and the best of climbers know.";
		dialogue[7,2] = "The jungle grows thicker here, where languid vines fall from the thick branches above. You push them aside and at your feet,to your surprise, a plastic baggy filled with catnip! There is a label on the baggy.";
		dialogue[8,2] = "The Jungle is growing thicker, and passage is decreasing in ease by the footstep.";
		dialogue[9,2] = "You meet a rock face where moss and straggly vines flow over the hard surface like a green waterfall of foliage. You don’t see a way through. To your West you see never-ending jungle, to your East, the flow of the river can be heard through the cover of trees.";
		//D row
		dialogue[0,3] = "The wide river flows down a steep embankment here and disappears out of site.";
		dialogue[1,3] = "The river flows quickly. Rocks emerge from the surface like slick, little islands.";
		dialogue[2,3] = "The flow of the river is steady. It’s glassy surface intrigues you. ";
		dialogue[3,3] = "The river flows swiftly away from the bridge.";
		dialogue[4,3] = "Here, a footpath leads to a narrow, wooden bridge. It’s rickety, shoddy design makes crossing tedious, and you almost lose your footing. But with a little extra effort, you make it safely.";
		dialogue[5,3] = "River water pools up here as debris have snared under the bridge, damming up the flow. It looks like a nice place for a bath, you think. Too bad the road is right over there.";
		dialogue[6,3] = "The river widens here and the water is shallow. It flows slowly.";
		dialogue[7,3] = "The opposite embankment is so far away.";
		dialogue[8,3] = "A spit has emerged from the river’s surface and a sandy island hosts a flock of pristine cranes. A flamingo stands oddly among them, one leg tucked under its belly.";
		dialogue[9,3] = "The river splits here, where the confluence of a larger river makes passage impossible.";
		//E row
		dialogue[0,4] = "The ground gives way beneath your feet and swampy water soaks your feet/talons/hooves.";
		dialogue[1,4] = "The terrane has turned into marshlands. Do you really want to get your feet/talons/hooves wet, adventurer?";
		dialogue[2,4] = "The thick grass gives way to reeds and soon you begin seeing patches of bamboo. You find an orchid in bloom and stop to take in it’s delicate beauty.";
		dialogue[3,4] = "The grasses are taller and come up to your waist in places.";
		dialogue[4,4] = "You meet up again with the pathway. To the west you make out the beginning of a bridge. You the East you see the main path again.";
		dialogue[5,4] = " Here the daffodils are plentiful and in the center of a larger patch you discover a huge daffodil which you mercifully pick without hesitation.";
		dialogue[6,4] = "Beautiful little yellow flowers begin to speckle the otherwise green grass.";
		dialogue[7,4] = "The field continues along the banks of the river. The grasses grow taller here.";
		dialogue[8,4] = "A field of grass and rough clumps of dirt makes walking somewhat hard.";
		dialogue[9,4] = "The castle wall leads around to the back where the flow of the river prevents you from continuing.";
		//F Row
		dialogue[0,5] = "At the edge of an endless desert you look on as three turkey vultures rip scraps off a dehydrated carcass. Your foot brushes against something hard and you uncover, buried in the sand, a bottle of chloroform!";
		dialogue[1,5] = "You trudge into the uneven sand and climb a small series of sand dunes. It’s not easy moving through this stuff.";
		dialogue[2,5] = "Here the path turns abruptly East. Ahead there are Dunes of sand which appear to be the beginning of a dessert and to your left more grass separates you from the river.";
		dialogue[3,5] = "To the West a patch of grass separates you from the bank of the river. To the East sand spills down a mound.";
		dialogue[4,5] = "A road sign offers directions; it reads: North - The Desert, South - Fourwood Castle, West - The River.";
		dialogue[5,5] = "Grass grows on either side of the path.";
		dialogue[6,5] = "The path leads away from the castle. To the West a river runs parallel along the roadway. To the East a small stream empties into a ditch beside the road.";
		dialogue[7,5] = "A road sign offers directions to this otherwise expansive land: \n North - Desert Dunes \nSouth - Fourwood Castle \nEast - Moonshadow Mountain";
		dialogue[8,5] = "The castle is behind you.  Ahead lies the great outdoors.";
		dialogue[9,5] = "The entrance to the castle stands mighty against the thick rock wall which surrounds it like an over-protective eggshell";
		//G row
		dialogue[0,6] = "Around to the side of the castle wall you find nothing. Fun!";
		dialogue[1,6] = "Here the sand slopes down into a small bowl where a lone sequoia reaches heights of 10 feet or more.";
		dialogue[2,6] = "The path leads East/West here providing passage across the sands of the desert.";
		dialogue[3,6] = "Sand spills over here and collects in piles. Some grass pokes up through sandy patches but is stifled by the oppressive desert feature.";
		//too long
		dialogue[4,6] = "Through reeds and tall grasses you see bees and insects in great detail.  You feel dizzy.";
		dialogue[5,6] = "Here a field of grass grows with surprising ease and you begin to wonder whether there is a stream or some other source to feed this thriving vegetation.";
		dialogue[6,6] = "You come to the head of a small creek. Its meandering flow empties at your feet and disappears into the loose gravel there.";
		dialogue[7,6] = "The path here butts up to the main trail in the West. To the East the path appears to lead into the mountains.";
		dialogue[8,6] = "A gentle slope of grass and wild flowers rises and climbs away from you. Beyond, you see the slope grows in height to a peak.";
		dialogue[9,6] = "You climb down the steep face of the peak and end up outside the castle walls.";
		//H row
		dialogue[0,7] = "Here the trail stops abruptly as passage has been cut off by a large family of boulders, which must have fallen from the hills above. Until they are moved, this trail ends right here.";
		dialogue[1,7] = "You make your way along the established path.";
		dialogue[2,7] = "The path continues to cut through the sandy desert. The heat bears down on you, and you begin to wonder if you aren’t seeing things when you gaze out to the East. To the West the story is the same.";
		dialogue[3,7] = "Patches of sand make travel difficult as the wind whips up grains and throws them against your face.";
		dialogue[4,7] = "A small hill protrudes from the Earth here and gives way to light vegetation. ";
		dialogue[5,7] = "Tucked neatly between two large hills, a pretty stream flowing on its other side, a glowing tree stands out against the landscape and captures your attention. It is purple and pink and green and blue. Nothing about this tree looks natural except for its shape. As you gaze at the spectacle you are struck with a pang in your gut.";
		dialogue[6,7] = "A calm stream flows here and the crystal clear water gives way to mineos and tadpoles and skeeters. You want to touch the cool water but something inside tells you not to, so you don’t.";
		dialogue[7,7] = "The small trail runs along the stream where steep hills to the South make passage that direction nearly impossible. To the East the mountains appear to grow much larger by the step.";
		dialogue[8,7] = "You climb the slope, trudging through the tall grass. Little bright spots of various color pockmark the mountain side. Here there is a shelf sitting below a ridge line where you stop to rest. \nTo the south the elevation climbs sharply to a peak. \nTo the south you see a stream in the distance, and a strange, glowing object.";
		dialogue[9,7] = "The trek to the top of the mountain is arduous and takes a great deal of your strength. But once you are on top, you have a view of the whole landscape. You find a bundle of cheeses and a baguette. \nTo the North you can see a river, expansive in places, where a little bridge acts like a bracelet across the thick arm of water. \nTo the east the ridgeline continues. \nTo the South the massive peak gives way to a cliff face the likes of which you hope never to fall from. \nTo the West you can make out the castle grounds. This must be what the birds see when they fly overhead.";
		//I row
		dialogue[0,8] = "Flowing sands reach across the landscape in all directions. This seemingly endless expanse makes you wish you had a camel.";
		dialogue[1,8] = "Amid dunes and sweeping wind you spot a small caravan of strange travelers. You pick up the pace and head in their direction. When you reach the group you come to your senses: this is just a gathering of cactus and nothing more. Suddenly your ankle triggers a trip-wire and a net leaps from the sand beneath your feet and scoops you up. You struggle against the net but find movement of any kind very difficult. You are trapped.";
		dialogue[2,8] = "Dunes of sand extend North and West and to the East small rolling hills but up against these dunes.";
		dialogue[3,8] = "Here grassy hills stand. Nothing much else catches your attention.";
		dialogue[4,8] = "Rocky outcroppings extend from the cliff face here there.";
		dialogue[5,8] = "The rolling hills appear to be fed by a stream you can see from here. A glowing, strange object remains hidden by these mounds to the West.";
		dialogue[6,8] = "Cool water cuts small banks into the sides of this quaint, little stream. It flows down from here in the direction of the West, and to the East you can see a rich swath of green.";
		dialogue[7,8] = "A path has been cut into the rocky walls of the mountains. It provides passage through the otherwise dangerous mountain range.";
		dialogue[8,8] = "Whoever made this passage must have worked themselves to the bone. Cutting through hard granite to make a trail is no little task.";
		dialogue[9,8] = "The hills slope down here to a small valley where the path butts up against them to the North. To your right and left the hills run endlessly in both directions.";
		//J row
		dialogue[0,9] = "A spit opens in the crust of the Earth and a pool of lava wells up from the depths.";
		dialogue[1,9] = "The air smells of sulfur here and heat begins feel oppressive on your skin.";
		dialogue[2,9] = "Hills, hills rolling hills. So much grass!";
		dialogue[3,9] = "The rolling hills begin to boast rocks as the impassible mountains butt up against them here.";
		dialogue[4,9] = "Steep crags jut from the dangerous mountains.";
		dialogue[5,9] = "As you traverse the uneven mountainside a cliff stops your progress but also gives way to a stunning view of the land below. Looking directly below you see a bright patch of vibrant green beyond which a small stream flows away, to the West.";
		dialogue[6,9] = "Thickets of green combine with tall reeds as water flows out of the rocky ground. You have discovered a natural spring! As you look at the refreshing, clear water, the reflection of something large and yellow catches your eye. You look up and your gaze is met by the likes of a huge dandelion! You waste no time in chopping it down and stuffing it into your pack! ";
		dialogue[7,9] = "The sounds of voices echo against the hard rock walls and before you know it, a band of gypsies have you locked in their sights. They look menacing and you make out daggers and swords in their hands.";
		dialogue[8,9] = "The narrow pathway leads sharply East through this rocky environment.";
		dialogue[9,9] = "The hills cease here where the mountain consumes them and boulders live scattered among wild flowers.";
		//K Row
		dialogue[0,10] = "Don’t touch. Hot lava";
		dialogue[1,10] = "Hot lava. Don’t touch.";
		dialogue[2,10] = "The sharp rocks slope down here and give way to hills in the West. In the North you can see bubbling, steaming pools of hot lava.";
		dialogue[3,10] = "At the outcropping of a massive boulder you discover the entrance to a cave. The spooky depths disappear into the cloak of darkness, but at the foot of the cave you find a small glass bottle of chloroform. Whatever this is doing here you’re sure glad this gas is contained in this bottle.";
		dialogue[4,10] = "Mountains. What are you doing up here.";
		dialogue[5,10] = "Mountains. What are you doing up here.";
		dialogue[6,10] = "Mountains. What are you doing up here.";
		dialogue[7,10] = "Mountains. What are you doing up here.";
		dialogue[8,10] = "The trail stops here and a signpost informs you the passage to the mountains has been closed by order of the King. “Too dangerous due to the presence of hostile bandits”, the sign declares. I guess you’ll have to stop here.";
		dialogue[9,10] = "You crest the high peak to the Southeast and wonder why you climbed all the way up here. To your astonishment you find a baggy of green leaves, the label of which assures you it's catnip. Catnip… Who’s bringing their kitties to the top of the mountains, you wonder.";


	}
	

}
