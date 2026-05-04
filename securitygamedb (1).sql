-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 04, 2026 at 08:28 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `securitygamedb`
--

-- --------------------------------------------------------

--
-- Table structure for table `scenarios`
--

CREATE TABLE `scenarios` (
  `ScenarioID` int(100) NOT NULL,
  `Scenario` varchar(1000) NOT NULL,
  `Answer` varchar(1000) NOT NULL,
  `Incorrect1` varchar(1000) NOT NULL,
  `Incorrect2` varchar(1000) NOT NULL,
  `Incorrect3` varchar(1000) NOT NULL,
  `Reason` varchar(1000) NOT NULL,
  `Summary` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `scenarios`
--

INSERT INTO `scenarios` (`ScenarioID`, `Scenario`, `Answer`, `Incorrect1`, `Incorrect2`, `Incorrect3`, `Reason`, `Summary`) VALUES
(1, 'You walk into the office at work, and you find a USB stick with no name on it lay on your desk, what do you do with the USB stick?', 'Take the USB stick to the IT team to be properly disposed of', 'Plug the USB stick into your computer to see if you can identify the correct owner', 'Ask around to see if anyone has lost a USB stick', 'Leave it where you found it', 'Attackers might upload malware to USB sticks and leave them around in order to infect machines, it’s critical that any USB sticks found are taken to be properly disposed of to prevent machines being infected unnecessarily.', 'Found USB stick'),
(2, 'You have stepped outside to smoke, the building requires key card access, and you are talking to someone else in the smoking area that you do not know. You both go to go back into the building. What should you do?', 'Close the door behind you so that the person can enter with an ID as they should', 'Hold the door open for the person to come in behind you', 'Confront the person and ask them to show you their ID', 'Stay outside until the person leaves or enters the building', 'Attackers may use tactics like waiting in the smoking area for someone to hold a door open as a way to get physical access to a building even though they don’t have a key card, they can then leverage this access to steal sensitive information, plug in key loggers or commit other malicious acts', 'Hold the door open?'),
(3, 'You are checking your emails, and you have received an email from someone claiming to be your boss however the email address doesn’t seem right, they know a lot of information about you such as that you just came back from a holiday. They are asking you to send over some sensitive information about a project you are completing. What should you do? ', 'Go and check with your boss or organise a call to check if it’s him as well as reporting the email to IT', 'Send the information over, he seems to know a lot about you anyway ', 'Delete the email and move on with your day', 'Show the email to the colleague to your left and just listen to whatever they say', 'Attackers are frequently becoming more sophisticated with their cyber-attack and social engineering efforts; they will research potential attacker’s social media accounts or other public information to see how they can deliver more targeted spear phishing attacks. If a request seems unusual then it probably is so reporting it and checking with the other member of staff is a good way of preventing a breach or leak of information.', 'Spear phishing email'),
(4, 'You are completing a task which involves sensitive information, you aren’t sure how to do it what should you do?', 'Ask a colleague or supervisor, or google to see if you can find the correct answer', 'Post the information into an AI such as ChatGPT to see if it can help', 'Post the information to a blog site to see if anyone on there can help', 'just leave it a pretend it doesn’t exist', 'asking a colleague is the easiest way to avoid leakage of sensitive information which can cause large fines for a company as even with something which might seem private like ChatGPT or other AI models they still store that information and may even use it to train their model which can lead to data leaks.', 'Unsure on work'),
(5, 'You have left you company laptop on a train when you went back to see if I was still there you couldn’t find; it contains sensitive information. What should you do?', 'Contact your IT department so they can remotely wipe the device and investigate any potential breaches', 'Pretend it didn’t happen as you don’t want to be charged for the laptop', 'Keep asking the train stations lost and found across multiple days in case it shows up without telling IT', 'Buy a new laptop and move on with your life', 'Attackers can steal your laptop and breach it to steal the sensitive information contained within, the potential monetary loss through that is much higher than just replacing the laptop. A remote wipe will delete this information preventing attackers from being able to steal it.', 'Left equipment'),
(6, 'You receive a social media DM from someone claiming to be a colleague asking for help and some information on a project your team is working on. What should you do?', 'Check if this is them at work tomorrow and offer the help there, if it wasn’t report it to the IT team', 'Send them the information, how would they know about the project if it isn’t them', 'Ignore it', 'Send it to another colleague to see if they know what to do', 'If you haven’t got this social media account from them you shouldn’t share any information with them in case they are someone pretending to be your colleague. Work information shouldn’t really be sent over non work communications as well as the proper security procedures might not be in place.', 'Social media phising'),
(7, 'A colleague has sent you an email with a link to download a game and says its super fun and you should download it and try it on the work computer. What should you do?', 'Report the email to the IT department as this might be a virus spreading via email', 'download it as it could be fun', 'ignore it', 'send the email to other colleagues in case they want to play as well', 'Attacks such as worms frequently use techniques like sending emails to spread across a network; by downloading the “game” you might unintentionally infect your machine and sharing it further even if you don’t download it can help further cause more damage. By reporting it you alert the IT team and they are able to investigate the emails and search for a potential breach.', 'Game download email'),
(8, 'You are about to go to the toilet, no one else usually accesses your computer however you are signed in. what should you do before you go to the toilet?', 'Lock the machine and then leave', 'leave the machine unlocked it’ll probably be fine', 'ask a colleague to watch it while you are gone', 'remember the tab you left it on and the position the mouse is in so you will know if anyone else accessed it', 'You never know people intentions; by locking your computer you prevent anyone accessing it and doing anything which could potentially lead to a breach and be attributed to you.', 'Leaving your computer'),
(9, 'You receive an email from a colleague which contains a suspicious attachment that you weren’t expecting such as planning.xls, what should you do?', 'Check with the colleague if they sent it and if they didn’t report it to the IT team', 'Ignore it', 'Open it, it’s from a colleague so it should be fine', 'Send it to other members of your team', 'If you aren’t expecting an email from someone or it seems unusual checking with them whether they were actually the sender can help to prevent any accidental data breaches. ', 'Suspicious email'),
(10, 'While you are working someone is stood behind you watching you, they aren’t involved with what you are doing, and you are about to view sensitive information. What should you do? ', 'Challenge the person and ask them to move on before accessing the sensitive information, if needed report them to your supervisor', 'Ignore the and continue what you were doing', 'Punch them', 'start doing random things to throw them off', 'Even if it’s a colleague you never know someone’s intentions, they may be watching to steal your password or just to steal whatever information is on your screen. If they aren’t meant to see the information, it is critical that they don’t as it can lead to sensitive data leaks or breaches of the system. ', 'Shoulder Surfing'),
(11, 'You go to log into your account first thing in the morning and for some reason the account is locked. What should you do?', 'Contact the IT department and explain the scenario to try and get your account unlocked', 'Ignore it and wait for the account to unlock', 'Move computer', 'Ask a colleague for their log in instead', 'There are many reasons your account might be locked however the most scary one is that someone has been trying to log in as you, by reporting it to the IT team they are able to look into the log in attempts to see if they were just accidents or an attempt at a breach.', 'Locked Account'),
(12, 'You are at work and a colleague says they are locked out of there account but are behind on a project and can’t wait for their account to unlock, they ask to use your account instead. What should you do? ', 'politely decline and mention it to your manger', 'Give them your account details as you want to help them out', 'you let them use your computer while they wait for their account to unlock', 'decline but suggest for them to ask someone else instead', 'Giving a colleague your password or access to your account is a huge security risk, even if they are a trusted user accounts are set up in such a way that they have access to the information they should and nothing more. Giving access to your account can lose traceability of actions and lead to unnecessary breaches which may fall back on you.', 'Sharing Accounts'),
(13, 'You are asked to give over your credit card details to a member of staff so they can take your portion of the money for the Christmas party. They want you to send the details via email. What should you do?', 'Report the email to your It department and manager', 'send them the bank details', 'send the email to other members of your team just in case they still need to pay', 'Respond to the email with a joke', 'credit card details should never be sent via email, if payment is needed for the Christmas party, they will likely take payment in a different manner. By sending you details over you risk attackers stealing your money.', 'Credit card scam'),
(14, 'You need a piece of software, but your company doesn’t have the proper license to it. What should you do? ', 'Speak to your manager and IT department to try and get the proper software licensed and downloaded', 'download a version from online without the correct license ', 'find a questionable site and download it from there', 'Use the version of the software you have at home', 'Not having proper software licensing can have large fines and downloading pirated software exposes the company to unnecessary risk of malware. Asking your IT to ensure that the software is installed and licensed properly minimising the risk of fines or data breaches.', 'Software installs'),
(15, 'You are receiving a link to a website however it seems suspicious, such as containing numbers instead of letters in the link. What should you do?', 'Don’t click the link and report it', 'Click the link it looks close enough', 'Send it to other members of staff to see if they know anything about it', 'Call your friend to see what they think', 'Attackers will often set up fake web pages which look really similar to actual domain names to steal information such as log in details, reporting these is critical to reduce the chance of others clicking them and the future and not clicking them is vital.', 'Questionable web link');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `scenarios`
--
ALTER TABLE `scenarios`
  ADD PRIMARY KEY (`ScenarioID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `scenarios`
--
ALTER TABLE `scenarios`
  MODIFY `ScenarioID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
